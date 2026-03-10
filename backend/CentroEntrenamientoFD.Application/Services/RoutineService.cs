using CentroEntrenamientoFD.Application.DTOs;
using CentroEntrenamientoFD.Application.Interfaces;
using CentroEntrenamientoFD.Application.Repositories.Interfaces;
using CentroEntrenamientoFD.Domain.Entities;

namespace CentroEntrenamientoFD.Application.Services
{
    public class RoutineService
    {
        private readonly IClientRoutineRepository _routineRepo;
        private readonly IRoutineExecutionRepository _executionRepo;

        public RoutineService(IClientRoutineRepository routineRepo,
        IRoutineExecutionRepository executionRepo)
        {
            _routineRepo = routineRepo;
            _executionRepo = executionRepo;
        }

        public async Task CreateRoutine(ClientRoutine routine)
        {
            _routineRepo.Add(routine);
        }

        public async Task CreateRoutineWithExecution(ClientRoutine routine)
        {
            await _routineRepo.Add(routine);

            var execution = new RoutineExecution(
                routine.UserId,
                routine.Id,
                1,
                DateTime.UtcNow
            );

            foreach (var day in routine.Days)
            {
                foreach (var exercise in day.Exercises)
                {
                    var exerciseExecution = execution.AddExerciseExecution(exercise.Id);

                    foreach (var slot in exercise.Slots)
                    {
                        exerciseExecution.AddMicroExecution(
                            slot.Order,
                            0,
                            0
                        );
                    }
                }
            }

            await _executionRepo.Add(execution);
        }

        public async Task CreateExecution(CreateExecutionDto dto, Guid userId)
        {
            var execution = new RoutineExecution(
              userId,
              dto.RoutineId,
              dto.WeekNumber,
              dto.Date
          );

            foreach (var exerciseDto in dto.Exercises)
            {
                var exerciseExecution = execution.AddExerciseExecution(exerciseDto.ExerciseId);

                foreach (var micro in exerciseDto.Micros)
                {
                    exerciseExecution.AddMicroExecution(
                        micro.Slot,
                        micro.Reps,
                        micro.Weight
                    );
                }
            }

            await _executionRepo.Add(execution);
        }

        public ClientRoutine? GetRoutine(Guid id)
        {
            return _routineRepo.GetById(id);
        }
    }
}
 
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

        public async Task CreateRoutineWithExecution(ClientRoutine routine, ClientRoutineDto dto)
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
                var dayDto = dto.Days.First(d => d.Day == day.DayNumber);

                foreach (var exercise in day.Exercises)
                {
                    var exerciseDto = dayDto.Exercises
                        .First(e => e.Name == exercise.Name);

                    var exerciseExecution = execution.AddExerciseExecution(exercise.Id);

                    var micro = exerciseDto.Micros.First(); // 👈 Micro 1

                    exerciseExecution.AddMicroExecution(
                        1,
                        micro.Reps,
                        micro.Weight
                    );
                }
            }

            await _executionRepo.Add(execution);
        }

        public async Task CreateExecution(CreateExecutionDto dto, Guid userId)
        {
            var existingExecutions = await _executionRepo
                .GetByRoutineIdAndUserId(dto.RoutineId, userId);

            var max = await _executionRepo.GetMaxMicroNumber(dto.RoutineId, userId);
            int nextSlot = max + 1;

            if (nextSlot > 4)
                throw new Exception("La rutina ya tiene los 4 micros completos");

            var execution = new RoutineExecution(
                userId,
                dto.RoutineId,
                nextSlot,
                dto.Date
            );

            foreach (var exerciseDto in dto.Exercises)
            {
                var exerciseExecution = execution.AddExerciseExecution(exerciseDto.ExerciseId);

                var micro = exerciseDto.Micros.First();

                exerciseExecution.AddMicroExecution(
                    nextSlot,
                    micro.Reps,
                    micro.Weight
                );
            }

            await _executionRepo.Add(execution);
        }

        public ClientRoutine? GetRoutine(Guid id)
        {
            return _routineRepo.GetById(id);
        }
    }
}
 
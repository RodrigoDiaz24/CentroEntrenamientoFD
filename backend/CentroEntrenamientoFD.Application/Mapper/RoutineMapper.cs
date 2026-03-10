using CentroEntrenamientoFD.Application.DTOs;
using CentroEntrenamientoFD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Application.Mapper
{
    public class RoutineMapper
    {
        public static ClientRoutine ToDomain(ClientRoutineDto dto, Guid userId)
        {
            var routine = new ClientRoutine(
             userId,
             dto.Date,
             dto.ClientName,
             dto.Objective
            );

            foreach (var mobility in dto.Mobility)
                routine.AddMobilityExercise(mobility);

            foreach (var dayDto in dto.Days)
            {
                var day = routine.AddRoutineDay(dayDto.Day);

                foreach (var exerciseDto in dayDto.Exercises)
                {
                    var exercise = day.AddExercise(exerciseDto.Name);

                    int order = 1;

                    foreach (var _ in exerciseDto.Micros)
                    {
                        exercise.AddSlot(order);
                        order++;
                    }
                }
            }

            return routine;
        }
    }
}

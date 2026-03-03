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
        public static ClientRoutine ToDomain(ClientRoutineDto dto)
        {
            var routine = new ClientRoutine(
            dto.Date,
            dto.ClientName,
            dto.Objective
        );

            foreach (var mobility in dto.Mobility)
            {
                routine.AddMobilityExercise(mobility);
            }

            foreach (var dayDto in dto.Days)
            {
                var day = routine.AddRoutineDay(dayDto.Day);

                foreach (var exerciseDto in dayDto.Exercises)
                {
                    var exercise = day.AddExercise(exerciseDto.Name);

                    foreach (var micro in exerciseDto.Micros)
                    {
                        exercise.AddMicro(micro);
                    }
                }
            }

            return routine;
        }
    }
}

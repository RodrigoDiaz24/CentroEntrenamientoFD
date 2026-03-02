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
            return new ClientRoutine(
                dto.Date,
                dto.ClientName,
                dto.Objective,
                dto.Mobility
                    .Select(m => new MobilityExercise(m))
                    .ToList(),
                dto.Days
                    .Select(d => new RoutineDay(
                        d.Day,
                        d.Exercises
                            .Select(e => new Exercise(
                                e.Name,
                                e.Micros.Select(m => new Micro(m)).ToList()
                            ))
                            .ToList()
                    ))
                    .ToList()
            );
        }
    }
}

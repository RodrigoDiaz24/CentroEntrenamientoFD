using CentroEntrenamientoFD.Application.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace CentroEntrenamientoFD.API.Swagger.Examples
{
    public class CreateExecutionDtoExample : IExamplesProvider<CreateExecutionDto>
    {
        public CreateExecutionDto GetExamples()
        {
            return new CreateExecutionDto
            {
                RoutineId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                WeekNumber = 2,
                Date = DateTime.UtcNow,
                Exercises = new List<ExerciseExecutionDto>
            {
                new ExerciseExecutionDto
                {
                    ExerciseId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Micros = new List<MicroDto>
                    {
                        new MicroDto { Slot = 1, Reps = 8, Weight = 65 },
                        new MicroDto { Slot = 2, Reps = 8, Weight = 65 }
                    }
                }
            }
            };
        }
    }
}

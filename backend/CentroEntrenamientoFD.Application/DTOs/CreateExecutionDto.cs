using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Application.DTOs
{
    public class CreateExecutionDto
    {
        public Guid RoutineId { get; set; }

        public int WeekNumber { get; set; }

        public DateTime Date { get; set; }

        public List<ExerciseExecutionDto> Exercises { get; set; }
    }
}

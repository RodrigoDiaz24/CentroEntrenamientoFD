using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Application.DTOs
{
    public class RoutineDayDto
    {
        public int Day { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
    }
}

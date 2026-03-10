using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Application.DTOs
{
    public class ExerciseExecutionDto
    {
        public Guid ExerciseId { get; set; }

        public List<MicroDto> Micros { get; set; }
    }
}

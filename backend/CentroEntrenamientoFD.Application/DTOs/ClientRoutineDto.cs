using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Application.DTOs
{
    public class ClientRoutineDto
    {
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public string Objective { get; set; }

        public List<string> Mobility { get; set; }
        public List<RoutineDayDto> Days { get; set; }
    }
}

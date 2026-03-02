using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class Exercise
    {
        public string Name { get; private set; }
        public IReadOnlyCollection<Micro> Micros { get; private set; }

        public Exercise(string name, List<Micro> micros)
        {
            Name = name;
            Micros = micros;
        }
    }
}

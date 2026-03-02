using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class MobilityExercise
    {
        public string Name { get; private set; }

        public MobilityExercise(string name)
        {
            Name = name;
        }
    }
}

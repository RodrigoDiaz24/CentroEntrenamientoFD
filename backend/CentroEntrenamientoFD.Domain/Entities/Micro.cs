using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class Micro
    {
        public string Value { get; private set; } = null!;

        private Micro() { }

        public Micro(string value)
        {
            Value = value;
        }
    }
}

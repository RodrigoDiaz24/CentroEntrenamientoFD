using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class Exercise
    {
        private readonly List<Micro> _micros = new();

        public string Name { get; private set; } = null!;

        public IReadOnlyCollection<Micro> Micros => _micros;

        private Exercise() { }

        public Exercise(string name)
        {
            Name = name;
        }

        public void AddMicro(string value)
        {
            _micros.Add(new Micro(value));
        }
    }
}

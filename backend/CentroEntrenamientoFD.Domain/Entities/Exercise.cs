using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class Exercise
    {
        private readonly List<MicroSlot> _slots = new();

        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        public IReadOnlyCollection<MicroSlot> Slots => _slots;

        private Exercise() { }

        public Exercise(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void AddSlot(int order)
        {
            _slots.Add(new MicroSlot(order));
        }
    }
}

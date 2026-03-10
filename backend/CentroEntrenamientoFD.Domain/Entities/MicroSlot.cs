using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class MicroSlot
    {
        public Guid Id { get; private set; }
        public int Order { get; private set; }

        private MicroSlot() { }

        public MicroSlot(int order)
        {
            Id = Guid.NewGuid();
            Order = order;
        }
    }
}

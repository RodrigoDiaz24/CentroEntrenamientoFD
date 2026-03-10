using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class MicroExecution
    {
        public Guid Id { get; private set; }

        public int SlotOrder { get; private set; }
        public int Reps { get; private set; }
        public decimal Weight { get; private set; }

        private MicroExecution() { }

        public MicroExecution(int slotOrder, int reps, decimal weight)
        {
            Id = Guid.NewGuid();
            SlotOrder = slotOrder;
            Reps = reps;
            Weight = weight;
        }
    }
}

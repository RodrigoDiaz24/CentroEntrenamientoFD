using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class ExerciseExecution
    {
        private readonly List<MicroExecution> _microExecutions = new();

        public Guid Id { get; private set; }
        public Guid ExerciseId { get; private set; }

        public IReadOnlyCollection<MicroExecution> MicroExecutions => _microExecutions;

        private ExerciseExecution() { }

        public ExerciseExecution(Guid exerciseId)
        {
            Id = Guid.NewGuid();
            ExerciseId = exerciseId;
        }

        public void AddMicroExecution(int slotOrder, int reps, decimal weight)
        {
            _microExecutions.Add(new MicroExecution(slotOrder, reps, weight));
        }
    }
}

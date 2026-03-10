using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class RoutineExecution
    {
        private readonly List<ExerciseExecution> _exerciseExecutions = new();

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ClientRoutineId { get; private set; }

        public int WeekNumber { get; private set; }
        public DateTime Date { get; private set; }

        public IReadOnlyCollection<ExerciseExecution> ExerciseExecutions => _exerciseExecutions;

        private RoutineExecution() { }

        public RoutineExecution(Guid userId, Guid routineId, int weekNumber, DateTime date)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            ClientRoutineId = routineId;
            WeekNumber = weekNumber;
            Date = date;
        }

        public ExerciseExecution AddExerciseExecution(Guid exerciseId)
        {
            var execution = new ExerciseExecution(exerciseId);
            _exerciseExecutions.Add(execution);
            return execution;
        }
    }
}

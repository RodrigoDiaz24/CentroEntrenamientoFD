using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class RoutineDay
    {
        private readonly List<Exercise> _exercises = new();

        public int DayNumber { get; private set; }

        public IReadOnlyCollection<Exercise> Exercises => _exercises;

        private RoutineDay() { }

        public RoutineDay(int dayNumber)
        {
            DayNumber = dayNumber;
        }

        public Exercise AddExercise(string name)
        {
            var exercise = new Exercise(name);
            _exercises.Add(exercise);
            return exercise;
        }
    }
}

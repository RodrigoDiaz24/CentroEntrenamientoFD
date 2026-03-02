using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class RoutineDay
    {
        public int DayNumber { get; private set; }
        public IReadOnlyCollection<Exercise> Exercises { get; private set; }

        public RoutineDay(int dayNumber, List<Exercise> exercises)
        {
            DayNumber = dayNumber;
            Exercises = exercises;
        }
    }
}

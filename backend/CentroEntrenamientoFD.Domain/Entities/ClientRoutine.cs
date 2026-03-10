using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class ClientRoutine
    {
        private readonly List<MobilityExercise> _mobility = new();
        private readonly List<RoutineDay> _days = new();

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }


        public DateTime Date { get; private set; }
        public string ClientName { get; private set; }
        public string Objective { get; private set; }

        public IReadOnlyCollection<MobilityExercise> Mobility { get; private set; }
        public IReadOnlyCollection<RoutineDay> Days { get; private set; }

        private ClientRoutine() { }

        public ClientRoutine(Guid userId, DateTime date, string clientName, string objective)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Date = date;
            ClientName = clientName;
            Objective = objective;
        }

        public void AddMobilityExercise(string name)
        {
            _mobility.Add(new MobilityExercise(name));
        }

        public RoutineDay AddRoutineDay(int dayNumber)
        {
            var day = new RoutineDay(dayNumber);
            _days.Add(day);
            return day;
        }
    }
}

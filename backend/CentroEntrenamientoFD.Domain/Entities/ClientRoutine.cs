using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Domain.Entities
{
    public class ClientRoutine
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string ClientName { get; private set; }
        public string Objective { get; private set; }

        public IReadOnlyCollection<MobilityExercise> Mobility { get; private set; }
        public IReadOnlyCollection<RoutineDay> Days { get; private set; }

        private ClientRoutine() { }

        public ClientRoutine(
            DateTime date,
            string clientName,
            string objective,
            List<MobilityExercise> mobility,
            List<RoutineDay> days)
        {
            Id = Guid.NewGuid();
            Date = date;
            ClientName = clientName;
            Objective = objective;
            Mobility = mobility;
            Days = days;
        }
    }
}

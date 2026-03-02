using CentroEntrenamientoFD.Application.Repositories.Interfaces;
using CentroEntrenamientoFD.Domain.Entities;

namespace CentroEntrenamientoFD.Infrastructure.Repositories
{
    public class RutinaInMemoryRepository : IRutinaRepository
    {

        private static readonly List<ClientRoutine> _rutinas = new();

        public void Agregar(ClientRoutine rutina)
        {
            // Evitamos duplicados por nombre (regla técnica simple)
            if (_rutinas.Any(r => r.ClientName == rutina.ClientName))
            {
                throw new InvalidOperationException(
                    $"Ya existe una rutina para el cliente {rutina.ClientName}");
            }

            _rutinas.Add(rutina);
        }

        public ClientRoutine? ObtenerPorNombre(string nombre)
        {
            return _rutinas
                .FirstOrDefault(r =>
                    r.ClientName.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<ClientRoutine> ObtenerTodas()
        {
            return _rutinas;
        }
    }
}

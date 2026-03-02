using CentroEntrenamientoFD.Application.Repositories.Interfaces;
using CentroEntrenamientoFD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Application.Services
{
    public class RoutineService
    {
        private readonly IRutinaRepository _repo;

        public RoutineService(IRutinaRepository repo)
        {
            _repo = repo;
        }

        public void CrearRutina(ClientRoutine rutina) => _repo.Agregar(rutina);

        public ClientRoutine ObtenerRutina(string nombre) => _repo.ObtenerPorNombre(nombre);
    }
}

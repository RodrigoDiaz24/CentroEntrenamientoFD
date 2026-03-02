using CentroEntrenamientoFD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Application.Repositories.Interfaces
{
    public interface IRutinaRepository
    {
        void Agregar(ClientRoutine rutina);
        ClientRoutine ObtenerPorNombre(string nombre);
    }
}

using CentroEntrenamientoFD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEntrenamientoFD.Application.Interfaces
{
    public interface IRoutineExecutionRepository
    {
        Task Add(RoutineExecution execution);
    }
}

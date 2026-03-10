using CentroEntrenamientoFD.Application.Interfaces;
using CentroEntrenamientoFD.Domain.Entities;
using CentroEntrenamientoFD.Infrastructure.Persistence;

namespace CentroEntrenamientoFD.Infrastructure.Repositories
{
    public class RoutineExecutionRepository : IRoutineExecutionRepository
    {
        private readonly AppDbContext _context;

        public RoutineExecutionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(RoutineExecution execution)
        {
            _context.RoutineExecutions.Add(execution);
            await _context.SaveChangesAsync();
        }
    }
}

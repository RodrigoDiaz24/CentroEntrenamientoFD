using CentroEntrenamientoFD.Application.Repositories.Interfaces;
using CentroEntrenamientoFD.Domain.Entities;
using CentroEntrenamientoFD.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CentroEntrenamientoFD.Infrastructure.Repositories
{
    public class ClientRoutineRepository : IClientRoutineRepository
    {
        private readonly AppDbContext _context;

        public ClientRoutineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(ClientRoutine routine)
        {
            _context.ClientRoutines.Add(routine);
            _context.SaveChanges();
        }

        public ClientRoutine? GetById(Guid id)
        {
            return _context.ClientRoutines
                .Include(r => r.Days)
                    .ThenInclude(d => d.Exercises)
                        .ThenInclude(e => e.Slots)
                .Include(r => r.Mobility)
                .FirstOrDefault(r => r.Id == id);
        }
    }
}

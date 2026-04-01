using CentroEntrenamientoFD.Application.Interfaces;
using CentroEntrenamientoFD.Domain.Entities;
using CentroEntrenamientoFD.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<RoutineExecution>> GetByRoutineIdAndUserId(Guid routineId, Guid userId)
        {
            return await _context.RoutineExecutions
                .Where(e => e.ClientRoutineId == routineId && e.UserId == userId)
                .Include(e => e.ExerciseExecutions)
                .ThenInclude(ex => ex.MicroExecutions)
                .ToListAsync();
        }

        public async Task<int> GetMaxMicroNumber(Guid routineId, Guid userId)
        {
            var max = await _context.RoutineExecutions
                .Where(e => e.ClientRoutineId == routineId && e.UserId == userId)
                .Select(e => (int?)e.WeekNumber) // 👈 nullable
                .MaxAsync();

            return max ?? 0;
        }
    }
}

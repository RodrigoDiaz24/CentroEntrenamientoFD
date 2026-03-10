using Microsoft.EntityFrameworkCore;
using CentroEntrenamientoFD.Domain.Entities;

namespace CentroEntrenamientoFD.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    // Template
    public DbSet<ClientRoutine> ClientRoutines => Set<ClientRoutine>();
    public DbSet<RoutineDay> RoutineDays => Set<RoutineDay>();
    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<MicroSlot> MicroSlots => Set<MicroSlot>();
    public DbSet<MobilityExercise> MobilityExercises => Set<MobilityExercise>();

    // Execution
    public DbSet<RoutineExecution> RoutineExecutions => Set<RoutineExecution>();
    public DbSet<ExerciseExecution> ExerciseExecutions => Set<ExerciseExecution>();
    public DbSet<MicroExecution> MicroExecutions => Set<MicroExecution>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
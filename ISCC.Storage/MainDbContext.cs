using System.Reflection;
using ISCC.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Storage;

public class MainDbContext(DbContextOptions<MainDbContext> options) : DbContext(options)
{
    public DbSet<ProjectEntity> Projects { get; set; }

    public DbSet<ProjectPlanEntity> ProjectPlans { get; set; }

    public DbSet<TaskEntity> Tasks { get; set; }

    public DbSet<GroupTaskEntity> GroupTasks { get; set; }
    public DbSet<ResourceEntity> Resources { get; set; }

    public DbSet<UnitTypeEntity> UnitTypes { get; set; }

    public DbSet<RegularExpenseEntity> RegularExpenses { get; set; }
    public DbSet<OneTimeExpenseEntity> OneTimeExpenses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(MainDbContext))!);
        
        base.OnModelCreating(modelBuilder);
    }
}
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> option) : base(option) { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
    public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeSkill>().HasKey(es => new { es.SkillId, es.EmployeeId });
        base.OnModelCreating(modelBuilder);
    }
}

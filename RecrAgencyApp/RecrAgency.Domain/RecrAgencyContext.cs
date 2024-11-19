using Microsoft.EntityFrameworkCore;

namespace RecrAgency.Domain;

/// <summary>
/// Контекст базы данных для управления данными кадрового агентства.
/// </summary>
public class RecrAgencyContext : DbContext
{
    public DbSet<Employer> Employers { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
    public DbSet<JobSeeker> JobSeekers { get; set; }
    public DbSet<EmployerApplication> EmployerApplications { get; set; }

    /// <summary>
    /// Конструктор для контекста базы данных с опциями.
    /// </summary>
    /// <param name="options">Опции для конфигурации контекста.</param>
    public RecrAgencyContext(DbContextOptions<RecrAgencyContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Настройка модели базы данных с помощью Fluent API.
    /// </summary>
    /// <param name="modelBuilder">Построитель моделей.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Настройка связи между JobSeekers и JobApplication
        modelBuilder.Entity<JobApplication>()
            .HasOne(ja => ja.JobSeeker)
            .WithMany(js => js.JobApplications)
            .HasForeignKey(ja => ja.SeekerId);

        // Настройка связи между Position и JobApplication
        modelBuilder.Entity<JobApplication>()
            .HasOne(ja => ja.Position)
            .WithMany(p => p.JobApplications)
            .HasForeignKey(ja => ja.PositionId);

        // Настройка связи между Employer и EmployerApplication
        modelBuilder.Entity<EmployerApplication>()
            .HasOne(ea => ea.Employer)
            .WithMany(e => e.EmployerApplications)
            .HasForeignKey(ea => ea.EmployerId);

        // Настройка связи между Position и EmployerApplication
        modelBuilder.Entity<EmployerApplication>()
            .HasOne(ea => ea.Position)
            .WithMany() 
            .HasForeignKey(ea => ea.PositionId);
    }
}


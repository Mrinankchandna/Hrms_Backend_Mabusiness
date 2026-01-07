using Microsoft.EntityFrameworkCore;
using Hrms.AttendanceService.Domain;

namespace Hrms.AttendanceService.Infrastructure;

public class AttendanceDbContext : DbContext
{
    public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) : base(options) { }

    public DbSet<Attendance> Attendances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.EmployeeId).IsRequired();
            entity.Property(e => e.CheckInTime).IsRequired();
            entity.Property(e => e.Status).HasMaxLength(20).IsRequired();
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.HasQueryFilter(e => !e.IsDeleted);
        });

        base.OnModelCreating(modelBuilder);
    }
}
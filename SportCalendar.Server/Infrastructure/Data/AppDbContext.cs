using Microsoft.EntityFrameworkCore;
using SportCalendar.Server.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SportCalendar.Server.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises => Set<Exercise>();
        public DbSet<ExerciseType> ExerciseTypes => Set<ExerciseType>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Status)
                .HasConversion<int>();

            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.ExerciseType)
                .WithMany(t => t.Exercises)
                .HasForeignKey(e => e.ExerciseTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

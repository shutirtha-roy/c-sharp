using EntityFrameworkDbContext.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDbContext.DbContexts
{
    public class TrainingContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public TrainingContext()
        {
            _connectionString = "Server = .\\SQLEXPRESS; Database = CSharpB8; User Id = csharpb8; Password = csharpb8;";
            _assemblyName = typeof(Program).Assembly.FullName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_assemblyName));
            }
            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Enrollment>()
                .HasKey(cs => new { cs.CourseId, cs.StudentId });

            builder.Entity<Enrollment>()
                .HasOne(pc => pc.Course)
                .WithMany(p => p.CourseEnrollment)
                .HasForeignKey(pc => pc.CourseId);

            builder.Entity<Enrollment>()
                .HasOne(pc => pc.Student)
                .WithMany(c => c.StudentEnrollment)
                .HasForeignKey(pc => pc.StudentId);

            base.OnModelCreating(builder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_core_Intro.Entitys;

namespace EF_core_Intro
{
    
    public class AppDBContext : DbContext
    {
        public DbSet<Entitys.Student> Students { get; set; }
        public DbSet<Entitys.Cafedra> Cafedras { get; set; }
        public DbSet<Entitys.Subject> Subjects { get; set; }
        public DbSet<Entitys.Pasport> Pasports { get; set; }
        public DbSet<Entitys.Teacher> Teachers { get; set; }
        public DbSet<Entitys.Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = EfDemo.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entitys.Student>(e => {
                e.ToTable("Student").HasKey(s => s.Id);
                e.Property(s => s.Name).HasColumnName("FullName").IsRequired().HasMaxLength(50);
                e.HasIndex(s => s.Age).IsUnique(true);
                e.Property(s => s.Name).IsRequired().HasMaxLength(50);
                e.Property(s => s.Scolarship).HasColumnType("decimal(6, 2)");
                e.HasIndex(s => s.Email).IsUnique();

                //e.HasCheckConstraint("CK_Student_Email", "[Email] Like '%@%.%'");
                e.ToTable(t => t.HasCheckConstraint("CK_Student_Email", "[Email] Like '%@%.%'"));
                e.Property(s => s.StudyFormat).HasConversion<string>();
                e.ToTable(t => t.HasCheckConstraint("CK_Student_StudyFormat", "[StudyFormat] IN ('FullTime', 'PartTime', 'Online', 'Gibrid')"));

                e.Property(e => e.Age).HasDefaultValue(18);
            });

            modelBuilder.Entity<Entitys.Pasport>(p =>
            {
                p.ToTable(t => t.HasCheckConstraint("CK_Pasport_Number", "LENGTH([Number]) = 9"));

            });

            modelBuilder.Entity<Entitys.Group>(e => {
                e.ToTable("Group").HasKey(g => g.Id);
                e.Property(g => g.Name).IsRequired().HasMaxLength(10);
            });

            modelBuilder.Entity<Entitys.Teacher>(t =>
            {
                t.ToTable("Teacher").HasKey(t => t.Id);
                t.Property(s => s.Salary).HasColumnType("decimal(8, 2)").HasDefaultValue(25000);
                t.Property(s => s.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Entitys.Subject>(s =>
            {
                s.ToTable("Subject").HasKey(s => s.Id);
                s.Property(s => s.Name).IsRequired().HasMaxLength(50);
                s.Property(s => s.Description).IsRequired();
            });

            modelBuilder.Entity<Entitys.Cafedra>(c =>
            {
                c.ToTable("Cafedra").HasKey(c => c.Id);
                c.Property(c => c.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Entitys.Student>()
                .HasOne(s => s.Pasport)
                .WithOne(p => p.Student)
                .HasForeignKey<Pasport>(p => p.StudentId);

            modelBuilder.Entity<Entitys.Group>()
                .HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Entitys.Teacher>()
                .HasMany(t => t.Subjects)
                .WithMany(s => s.Teachers)
                .UsingEntity(j => j.ToTable("TeachersSubjects"));

            modelBuilder.Entity<Entitys.Subject>()
                .HasOne(s => s.Cafedra)
                .WithMany(c => c.Subjects)
                .HasForeignKey(s => s.CafedraId);

            modelBuilder.Entity<Entitys.Subject>()
                .HasMany(s => s.Teachers)
                .WithMany(t => t.Subjects)
                .UsingEntity(j => j.ToTable("TeachersSubjects"));

            modelBuilder.Entity<Entitys.Cafedra>()
                .HasMany(c => c.Subjects)
                .WithOne(s => s.Cafedra)
                .HasForeignKey(s => s.CafedraId);
        }
    }
    
}

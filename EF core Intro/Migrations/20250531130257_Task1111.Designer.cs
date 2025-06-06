﻿// <auto-generated />
using EF_core_Intro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_core_Intro.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20250531130257_Task1111")]
    partial class Task1111
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("EF_core_Intro.Entitys.Cafedra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Financing")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cafedra", (string)null);
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Group", (string)null);
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Pasport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Pasports", t =>
                        {
                            t.HasCheckConstraint("CK_Pasport_Number", "LENGTH([Number]) = 9");
                        });
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(18);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("FullName");

                    b.Property<float?>("Scolarship")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("StudyFormat")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Age")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("GroupId");

                    b.ToTable("Student", null, t =>
                        {
                            t.HasCheckConstraint("CK_Student_Email", "[Email] Like '%@%.%'");

                            t.HasCheckConstraint("CK_Student_StudyFormat", "[StudyFormat] IN ('FullTime', 'PartTime', 'Online', 'Gibrid')");
                        });
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CafedraId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Time")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CafedraId");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CafedraId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Salary")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8, 2)")
                        .HasDefaultValue(25000m);

                    b.HasKey("Id");

                    b.HasIndex("CafedraId");

                    b.ToTable("Teacher", (string)null);
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeachersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubjectsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("TeachersSubjects", (string)null);
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Pasport", b =>
                {
                    b.HasOne("EF_core_Intro.Entitys.Student", "Student")
                        .WithOne("Pasport")
                        .HasForeignKey("EF_core_Intro.Entitys.Pasport", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Student", b =>
                {
                    b.HasOne("EF_core_Intro.Entitys.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Subject", b =>
                {
                    b.HasOne("EF_core_Intro.Entitys.Cafedra", "Cafedra")
                        .WithMany("Subjects")
                        .HasForeignKey("CafedraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cafedra");
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Teacher", b =>
                {
                    b.HasOne("EF_core_Intro.Entitys.Cafedra", "Cafedra")
                        .WithMany("Teachers")
                        .HasForeignKey("CafedraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cafedra");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("EF_core_Intro.Entitys.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_core_Intro.Entitys.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Cafedra", b =>
                {
                    b.Navigation("Subjects");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("EF_core_Intro.Entitys.Student", b =>
                {
                    b.Navigation("Pasport")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

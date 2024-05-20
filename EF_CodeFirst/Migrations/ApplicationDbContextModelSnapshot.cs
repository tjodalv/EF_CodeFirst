﻿// <auto-generated />
using System;
using EF_CodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_CodeFirst.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_CodeFirst.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"));

                    b.Property<string>("GradeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("GradeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            GradeId = 1,
                            GradeName = "odličan",
                            Section = "Matematika",
                            StudentId = 1
                        },
                        new
                        {
                            GradeId = 2,
                            GradeName = "vrlo dobar",
                            Section = "Hrvatski jezik",
                            StudentId = 1
                        },
                        new
                        {
                            GradeId = 3,
                            GradeName = "odličan",
                            Section = "Biologija",
                            StudentId = 1
                        },
                        new
                        {
                            GradeId = 4,
                            GradeName = "dobar",
                            Section = "Kemija",
                            StudentId = 1
                        },
                        new
                        {
                            GradeId = 5,
                            GradeName = "vrlo dobar",
                            Section = "Matematika",
                            StudentId = 2
                        },
                        new
                        {
                            GradeId = 6,
                            GradeName = "odličan",
                            Section = "Fizika",
                            StudentId = 2
                        },
                        new
                        {
                            GradeId = 7,
                            GradeName = "odličan",
                            Section = "Hrvatski jezik",
                            StudentId = 2
                        });
                });

            modelBuilder.Entity("EF_CodeFirst.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("StudentId");

                    b.ToTable("Studenti");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            DateOfBirth = new DateTime(2000, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Height = 1.75m,
                            StudentName = "Pero Perić",
                            Weight = 70f
                        },
                        new
                        {
                            StudentId = 2,
                            DateOfBirth = new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Height = 1.85m,
                            StudentName = "Ivo Ivić",
                            Weight = 85f
                        });
                });

            modelBuilder.Entity("EF_CodeFirst.Grade", b =>
                {
                    b.HasOne("EF_CodeFirst.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EF_CodeFirst.Student", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}

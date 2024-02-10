﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vpsAPI.Services;

#nullable disable

namespace vpsAPI.Migrations
{
    [DbContext(typeof(VPSContext))]
    [Migration("20230111123941_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("vpsAPI.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            DepartmentID = 1,
                            CreatedBy = "1",
                            CreatedDate = new DateTime(2023, 1, 11, 17, 39, 41, 526, DateTimeKind.Local).AddTicks(872),
                            DepartmentDescription = "All courses related to the computer domain",
                            DepartmentName = "Computer Science"
                        },
                        new
                        {
                            DepartmentID = 2,
                            CreatedBy = "1",
                            CreatedDate = new DateTime(2023, 1, 11, 17, 39, 41, 526, DateTimeKind.Local).AddTicks(890),
                            DepartmentDescription = "All courses related to the physics domain",
                            DepartmentName = "Physics"
                        },
                        new
                        {
                            DepartmentID = 3,
                            CreatedBy = "1",
                            CreatedDate = new DateTime(2023, 1, 11, 17, 39, 41, 526, DateTimeKind.Local).AddTicks(893),
                            DepartmentDescription = "All courses related to the maths domain",
                            DepartmentName = "Mathemathics"
                        });
                });

            modelBuilder.Entity("vpsAPI.Models.Groups", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("GroupDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("vpsAPI.Models.Students", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("AcademicPerformance")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("StudentAge")
                        .HasColumnType("int");

                    b.Property<string>("StudentFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("vpsAPI.Models.Groups", b =>
                {
                    b.HasOne("vpsAPI.Models.Department", "Department")
                        .WithMany("Groups")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("vpsAPI.Models.Students", b =>
                {
                    b.HasOne("vpsAPI.Models.Groups", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("vpsAPI.Models.Department", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("vpsAPI.Models.Groups", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}

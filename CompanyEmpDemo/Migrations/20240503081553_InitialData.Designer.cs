﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace CompanyEmpDemo.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240503081553_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CompanyId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Address = "Gali no.420, Thaltej, Ahmedabad 380058",
                            Country = "IND",
                            Name = "IT_Solutions Ltd"
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Address = "Gali no.251, Shilaj, Ahmedabad 380059",
                            Country = "IND",
                            Name = "Admin_Solutions Ltd"
                        });
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EmployeeId");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("37ce4894-d97f-475a-8285-0a1a5069e3d1"),
                            Age = 34,
                            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Denish Makadiya",
                            Position = "Sr. UnityDeveloper"
                        },
                        new
                        {
                            Id = new Guid("53060844-f781-4395-96dc-be17fe0c9cde"),
                            Age = 26,
                            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Pawan Rajput",
                            Position = "UnityDeveloper"
                        },
                        new
                        {
                            Id = new Guid("dbfb00a5-4970-4dc3-8e62-650da3edb2ae"),
                            Age = 25,
                            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Sachin Tomar",
                            Position = "Frontend Developer"
                        },
                        new
                        {
                            Id = new Guid("d3529e39-c5d2-4103-835d-e2a0e8e5f04b"),
                            Age = 28,
                            CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "Rahul Tripathi",
                            Position = "Administrator"
                        });
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.HasOne("Entities.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Entities.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

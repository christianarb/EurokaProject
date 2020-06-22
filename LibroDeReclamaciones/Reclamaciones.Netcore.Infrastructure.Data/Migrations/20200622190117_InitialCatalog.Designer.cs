﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Netcore.Infrastructure.Data.Context;

namespace Netcore.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200622190117_InitialCatalog")]
    partial class InitialCatalog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Netcore.Domain.Agregates.AFPAgg.Afp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasComment("Nombre de la afp");

                    b.HasKey("Id");

                    b.ToTable("Afp");
                });

            modelBuilder.Entity("Netcore.Domain.Agregates.CargoEmpledoAgg.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasComment("Nombre del cargo");

                    b.HasKey("Id");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("Netcore.Domain.Agregates.EmpleadoAgg.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasComment("Apellido materno de la persona");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasComment("Apellido paterno de la persona");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAfp")
                        .HasColumnType("int");

                    b.Property<int>("IdCargo")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasComment("Nombre de la persona");

                    b.HasKey("Id");

                    b.HasIndex("IdAfp");

                    b.HasIndex("IdCargo");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("Netcore.Domain.Agregates.EmpleadoAgg.Empleado", b =>
                {
                    b.HasOne("Netcore.Domain.Agregates.AFPAgg.Afp", "Afp")
                        .WithMany("Empleado")
                        .HasForeignKey("IdAfp")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Netcore.Domain.Agregates.CargoEmpledoAgg.Cargo", "Cargo")
                        .WithMany("Empleado")
                        .HasForeignKey("IdCargo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

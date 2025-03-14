﻿// <auto-generated />
using System;
using BackendSeguros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendSeguros.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendSeguros.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("FecNacimiento")
                        .HasColumnType("date");

                    b.Property<DateTime>("FecRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rtn")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("TipoPersona")
                        .HasColumnType("int");

                    b.Property<string>("celular")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("BackendSeguros.Models.Cobertura", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<double>("Deducible")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FecRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCobertura")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ramoId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ramoId");

                    b.ToTable("Cobertura");
                });

            modelBuilder.Entity("BackendSeguros.Models.Corredor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodCorredor")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FecRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("celular")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("id");

                    b.ToTable("Corredor");
                });

            modelBuilder.Entity("BackendSeguros.Models.Poliza", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("FecRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<decimal>("comision")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("corredorId")
                        .HasColumnType("int");

                    b.Property<decimal>("cuota")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("impuesto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("montoAsegurar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("montoNeto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("prima")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ramoId")
                        .HasColumnType("int");

                    b.Property<decimal>("totalPagar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("clienteId");

                    b.HasIndex("corredorId");

                    b.HasIndex("ramoId");

                    b.ToTable("Poliza");
                });

            modelBuilder.Entity("BackendSeguros.Models.Ramo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FecRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreRamos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Ramo");
                });

            modelBuilder.Entity("BackendSeguros.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("FecRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BackendSeguros.Models.Cobertura", b =>
                {
                    b.HasOne("BackendSeguros.Models.Ramo", "Ramo")
                        .WithMany()
                        .HasForeignKey("ramoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ramo");
                });

            modelBuilder.Entity("BackendSeguros.Models.Poliza", b =>
                {
                    b.HasOne("BackendSeguros.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackendSeguros.Models.Corredor", "Corredor")
                        .WithMany()
                        .HasForeignKey("corredorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackendSeguros.Models.Ramo", "Ramo")
                        .WithMany()
                        .HasForeignKey("ramoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Corredor");

                    b.Navigation("Ramo");
                });
#pragma warning restore 612, 618
        }
    }
}

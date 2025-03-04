﻿// <auto-generated />
using System;
using BackendSeguros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendSeguros.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250302032620_UpdateRamos2")]
    partial class UpdateRamos2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendSeguros.Models.Cobertura", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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

            modelBuilder.Entity("BackendSeguros.Models.Cobertura", b =>
                {
                    b.HasOne("BackendSeguros.Models.Ramo", "Ramo")
                        .WithMany()
                        .HasForeignKey("ramoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ramo");
                });
#pragma warning restore 612, 618
        }
    }
}

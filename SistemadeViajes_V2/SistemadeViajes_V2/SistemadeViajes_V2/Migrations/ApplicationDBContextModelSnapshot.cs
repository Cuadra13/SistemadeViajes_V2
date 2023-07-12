﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemadeViajes_V2;

#nullable disable

namespace SistemadeViajes_V2.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemadeViajes_V2.Entidades.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("colaboradorid")
                        .HasColumnType("int");

                    b.Property<int>("idcolaborador")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("colaboradorid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SistemadeViajes_V2.Entidades.Viaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<double>("Distancia")
                        .HasColumnType("float");

                    b.Property<DateTime>("FechaViaje")
                        .HasColumnType("datetime2");

                    b.Property<int>("SucursalId")
                        .HasColumnType("int");

                    b.Property<string>("Transportista")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("SucursalId");

                    b.ToTable("Viajes");
                });

            modelBuilder.Entity("SistemadeViajes_V2.Entidades.colaborador", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Perfil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("casa")
                        .HasColumnType("float");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("colaborador");
                });

            modelBuilder.Entity("SistemadeViajes_V2.Entidades.sucursales", b =>
                {
                    b.Property<int>("IdSucursal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSucursal"));

                    b.Property<double>("Distancia")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("colaboradorid")
                        .HasColumnType("int");

                    b.Property<int>("idcolaborador")
                        .HasColumnType("int");

                    b.HasKey("IdSucursal");

                    b.HasIndex("colaboradorid");

                    b.ToTable("sucursales");
                });

            modelBuilder.Entity("SistemadeViajes_V2.Entidades.User", b =>
                {
                    b.HasOne("SistemadeViajes_V2.Entidades.colaborador", "colaborador")
                        .WithMany()
                        .HasForeignKey("colaboradorid");

                    b.Navigation("colaborador");
                });

            modelBuilder.Entity("SistemadeViajes_V2.Entidades.Viaje", b =>
                {
                    b.HasOne("SistemadeViajes_V2.Entidades.colaborador", "Colaborador")
                        .WithMany()
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemadeViajes_V2.Entidades.sucursales", "Sucursal")
                        .WithMany()
                        .HasForeignKey("SucursalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("SistemadeViajes_V2.Entidades.sucursales", b =>
                {
                    b.HasOne("SistemadeViajes_V2.Entidades.colaborador", "colaborador")
                        .WithMany("sucursales")
                        .HasForeignKey("colaboradorid");

                    b.Navigation("colaborador");
                });

            modelBuilder.Entity("SistemadeViajes_V2.Entidades.colaborador", b =>
                {
                    b.Navigation("sucursales");
                });
#pragma warning restore 612, 618
        }
    }
}

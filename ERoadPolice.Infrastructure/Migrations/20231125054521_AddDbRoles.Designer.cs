﻿// <auto-generated />
using System;
using ERoadPolice.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERoadPolice.Infrastructure.Migrations
{
    [DbContext(typeof(PoliceRoadDbContext))]
    [Migration("20231125054521_AddDbRoles")]
    partial class AddDbRoles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ERoadPolice.Domain.Entities.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DriverId"));

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("LicenseNumber")
                        .HasColumnType("text");

                    b.Property<string>("OnlyIdentificationNumber")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("DriverId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("ERoadPolice.Domain.Entities.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IncidentId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CarNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("FineAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("OfficerId")
                        .HasColumnType("integer");

                    b.HasKey("IncidentId");

                    b.HasIndex("DriverId");

                    b.HasIndex("OfficerId");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("ERoadPolice.Domain.Entities.Officer", b =>
                {
                    b.Property<int>("OfficerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OfficerId"));

                    b.Property<string>("BadgeNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OfficerId");

                    b.ToTable("Officers");
                });

            modelBuilder.Entity("ERoadPolice.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("DriverIds")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ExpireTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RefreshTokenValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("ERoadPolice.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ERoadPolice.Domain.Entities.Incident", b =>
                {
                    b.HasOne("ERoadPolice.Domain.Entities.Driver", "Driver")
                        .WithMany("Incidents")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERoadPolice.Domain.Entities.Officer", "Officer")
                        .WithMany("Incidents")
                        .HasForeignKey("OfficerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Officer");
                });

            modelBuilder.Entity("ERoadPolice.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("ERoadPolice.Domain.Entities.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("ERoadPolice.Domain.Entities.Role", b =>
                {
                    b.HasOne("ERoadPolice.Domain.Entities.Role", null)
                        .WithMany("Roles")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("ERoadPolice.Domain.Entities.Driver", b =>
                {
                    b.Navigation("Incidents");
                });

            modelBuilder.Entity("ERoadPolice.Domain.Entities.Officer", b =>
                {
                    b.Navigation("Incidents");
                });

            modelBuilder.Entity("ERoadPolice.Domain.Entities.Role", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entities.City", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("AverageTemperature")
                        .HasColumnType("float");

                    b.Property<double>("CurrentTemperature")
                        .HasColumnType("float");

                    b.Property<double>("MaxTemperature")
                        .HasColumnType("float");

                    b.Property<double>("MinTemperature")
                        .HasColumnType("float");

                    b.HasKey("Name");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DataLayer.Entities.Measure", b =>
                {
                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ArchiveStatus")
                        .HasColumnType("bit");

                    b.Property<double>("Tempereture")
                        .HasColumnType("float");

                    b.HasKey("CityName", "Time");

                    b.ToTable("Measures");
                });

            modelBuilder.Entity("DataLayer.Entities.Measure", b =>
                {
                    b.HasOne("DataLayer.Entities.City", "City")
                        .WithMany("Measures")
                        .HasForeignKey("CityName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("DataLayer.Entities.City", b =>
                {
                    b.Navigation("Measures");
                });
#pragma warning restore 612, 618
        }
    }
}

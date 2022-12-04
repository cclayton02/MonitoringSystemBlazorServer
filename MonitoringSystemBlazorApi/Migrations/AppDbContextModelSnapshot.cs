﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonitoringSystemBlazorApi.Models;

#nullable disable

namespace MonitoringSystemBlazorApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MonitoringSystemBlazorShared.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FeedingSchedule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HealthConcerns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 5,
                            FeedingSchedule = "Twice daily",
                            HealthConcerns = "Cut on left front paw",
                            Name = "Leo",
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Age = 15,
                            FeedingSchedule = "3x per day",
                            HealthConcerns = "",
                            Name = "Maj",
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Age = 1,
                            FeedingSchedule = "",
                            HealthConcerns = "",
                            Name = "Baloo",
                            Type = 2
                        },
                        new
                        {
                            Id = 4,
                            Age = 12,
                            FeedingSchedule = "Grazing",
                            HealthConcerns = "",
                            Name = "Spots",
                            Type = 3
                        });
                });

            modelBuilder.Entity("MonitoringSystemBlazorShared.Habitat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FoodSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsClean")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Temp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Habitats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FoodSource = "Fish in water running low",
                            IsClean = true,
                            Name = "Penguin",
                            Temp = 1
                        },
                        new
                        {
                            Id = 2,
                            FoodSource = "Natural from environment",
                            IsClean = true,
                            Name = "Bird",
                            Temp = 3
                        },
                        new
                        {
                            Id = 3,
                            FoodSource = "Added daily",
                            IsClean = false,
                            Name = "Aquarium",
                            Temp = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task1.Data;

#nullable disable

namespace Task1.Migrations
{
    [DbContext(typeof(ProgramDbContext))]
    [Migration("20250415044949_AddedColoursTable")]
    partial class AddedColoursTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ColoursVehicles", b =>
                {
                    b.Property<int>("ColoursId")
                        .HasColumnType("int");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("int");

                    b.HasKey("ColoursId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("ColoursVehicles");
                });

            modelBuilder.Entity("Task1.Models.Brands", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Task1.Models.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Task1.Models.Colours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("Colours");
                });

            modelBuilder.Entity("Task1.Models.Stocks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("VehicleId")
                        .IsUnique();

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Task1.Models.Vehicles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Vehicles", t =>
                        {
                            t.HasCheckConstraint("CK_Vehicles_Price", "[Price] >= 200000 AND [Price] <= 200000000");

                            t.HasCheckConstraint("CK_Vehicles_Rating", "[Rating] >=0 AND [Rating] <=5");
                        });
                });

            modelBuilder.Entity("ColoursVehicles", b =>
                {
                    b.HasOne("Task1.Models.Colours", null)
                        .WithMany()
                        .HasForeignKey("ColoursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task1.Models.Vehicles", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Task1.Models.Stocks", b =>
                {
                    b.HasOne("Task1.Models.Vehicles", "Vehicle")
                        .WithOne("Stocks")
                        .HasForeignKey("Task1.Models.Stocks", "VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Task1.Models.Vehicles", b =>
                {
                    b.HasOne("Task1.Models.Brands", "Brands")
                        .WithMany("Vehicle")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task1.Models.Categories", "Categories")
                        .WithMany("Vehicles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brands");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Task1.Models.Brands", b =>
                {
                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Task1.Models.Categories", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Task1.Models.Vehicles", b =>
                {
                    b.Navigation("Stocks")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

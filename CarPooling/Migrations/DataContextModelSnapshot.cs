﻿// <auto-generated />
using System;
using CarPooling.Data;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarPooling.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarPooling.Models.ChatTrip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<int?>("DriverId");

                    b.Property<string>("Message");

                    b.Property<int>("TridId");

                    b.Property<int?>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DriverId");

                    b.HasIndex("TripId");

                    b.ToTable("ChatTrips");
                });

            modelBuilder.Entity("CarPooling.Models.ClientTrip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("Distance");

                    b.Property<string>("Duration");

                    b.Property<int?>("FromLocationId");

                    b.Property<DateTime>("LeavedAt");

                    b.Property<DateTime>("StartedAt");

                    b.Property<int>("Status");

                    b.Property<string>("SuggestedPrice");

                    b.Property<int?>("ToLocationId");

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("FromLocationId");

                    b.HasIndex("ToLocationId");

                    b.HasIndex("TripId");

                    b.ToTable("ClientTrips");
                });

            modelBuilder.Entity("CarPooling.Models.ClientTripPointAtTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<int?>("ClientTripId");

                    b.Property<IPoint>("Location");

                    b.Property<DateTime>("Time");

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ClientTripId");

                    b.HasIndex("TripId");

                    b.ToTable("ClientInTripPoints");
                });

            modelBuilder.Entity("CarPooling.Models.Connection", b =>
                {
                    b.Property<string>("ConnectionID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Connected");

                    b.Property<int?>("DriverId");

                    b.Property<string>("UserAgent");

                    b.HasKey("ConnectionID");

                    b.HasIndex("DriverId");

                    b.ToTable("Connection");
                });

            modelBuilder.Entity("CarPooling.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<IPoint>("Location");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("CarPooling.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId");

                    b.Property<int?>("DriverId");

                    b.Property<int?>("FinalLocationId");

                    b.Property<int?>("StartLocationId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DriverId");

                    b.HasIndex("FinalLocationId");

                    b.HasIndex("StartLocationId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("CarPooling.Models.TripPointAtTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<IPoint>("Location");

                    b.Property<DateTime>("Time");

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripPoints");
                });

            modelBuilder.Entity("CarPooling.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<byte[]>("HashPassword");

                    b.Property<string>("Name");

                    b.Property<string>("Role");

                    b.Property<byte[]>("SaltPassword");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("CarPooling.Models.Client", b =>
                {
                    b.HasBaseType("CarPooling.Models.User");

                    b.Property<bool>("Activated");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("CarPooling.Models.Driver", b =>
                {
                    b.HasBaseType("CarPooling.Models.User");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastOnlineAt");

                    b.Property<IPoint>("Location");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasDiscriminator().HasValue("Driver");
                });

            modelBuilder.Entity("CarPooling.Models.ChatTrip", b =>
                {
                    b.HasOne("CarPooling.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarPooling.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.HasOne("CarPooling.Models.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("CarPooling.Models.ClientTrip", b =>
                {
                    b.HasOne("CarPooling.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarPooling.Models.Place", "FromLocation")
                        .WithMany()
                        .HasForeignKey("FromLocationId");

                    b.HasOne("CarPooling.Models.Place", "ToLocation")
                        .WithMany()
                        .HasForeignKey("ToLocationId");

                    b.HasOne("CarPooling.Models.Trip")
                        .WithMany("Clients")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarPooling.Models.ClientTripPointAtTime", b =>
                {
                    b.HasOne("CarPooling.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarPooling.Models.ClientTrip")
                        .WithMany("Points")
                        .HasForeignKey("ClientTripId");

                    b.HasOne("CarPooling.Models.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarPooling.Models.Connection", b =>
                {
                    b.HasOne("CarPooling.Models.Driver")
                        .WithMany("Connections")
                        .HasForeignKey("DriverId");
                });

            modelBuilder.Entity("CarPooling.Models.Trip", b =>
                {
                    b.HasOne("CarPooling.Models.Client")
                        .WithMany("Trips")
                        .HasForeignKey("ClientId");

                    b.HasOne("CarPooling.Models.Driver", "Driver")
                        .WithMany("Trips")
                        .HasForeignKey("DriverId");

                    b.HasOne("CarPooling.Models.Place", "FinalLocation")
                        .WithMany()
                        .HasForeignKey("FinalLocationId");

                    b.HasOne("CarPooling.Models.Place", "StartLocation")
                        .WithMany()
                        .HasForeignKey("StartLocationId");
                });

            modelBuilder.Entity("CarPooling.Models.TripPointAtTime", b =>
                {
                    b.HasOne("CarPooling.Models.Trip", "Trip")
                        .WithMany("Points")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RemoteApi.Model;

#nullable disable

namespace RemoteApi.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20231113171426_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppUserConcert", b =>
                {
                    b.Property<long>("ConcertsId")
                        .HasColumnType("bigint");

                    b.Property<string>("UsersSub")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ConcertsId", "UsersSub");

                    b.HasIndex("UsersSub");

                    b.ToTable("AppUserConcert");
                });

            modelBuilder.Entity("RemoteApi.Model.AppUser", b =>
                {
                    b.Property<string>("Sub")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Sub");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RemoteApi.Model.Concert", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("ConcertType")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Concerts");

                    b.HasDiscriminator<int>("ConcertType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RemoteApi.Model.ConcertInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ConcertId")
                        .HasColumnType("bigint");

                    b.Property<string>("Performer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoldTickets")
                        .HasColumnType("int");

                    b.Property<int>("TotalTickets")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConcertId")
                        .IsUnique();

                    b.ToTable("ConcertInfo");
                });

            modelBuilder.Entity("RemoteApi.Model.ClassicConcert", b =>
                {
                    b.HasBaseType("RemoteApi.Model.Concert");

                    b.Property<string>("Conductor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VocalistVoice")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("RemoteApi.Model.OpenAir", b =>
                {
                    b.HasBaseType("RemoteApi.Model.Concert");

                    b.Property<string>("Headliner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HowToReach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("RemoteApi.Model.Party", b =>
                {
                    b.HasBaseType("RemoteApi.Model.Concert");

                    b.Property<byte>("MinAge")
                        .HasColumnType("tinyint");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("AppUserConcert", b =>
                {
                    b.HasOne("RemoteApi.Model.Concert", null)
                        .WithMany()
                        .HasForeignKey("ConcertsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RemoteApi.Model.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UsersSub")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RemoteApi.Model.ConcertInfo", b =>
                {
                    b.HasOne("RemoteApi.Model.Concert", null)
                        .WithOne("ConcertInfo")
                        .HasForeignKey("RemoteApi.Model.ConcertInfo", "ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("RemoteApi.Model.Location", "Location", b1 =>
                        {
                            b1.Property<long>("ConcertInfoId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ConcertInfoId");

                            b1.ToTable("ConcertInfo");

                            b1.WithOwner()
                                .HasForeignKey("ConcertInfoId");

                            b1.OwnsOne("RemoteApi.Model.Address", "Address", b2 =>
                                {
                                    b2.Property<long>("LocationConcertInfoId")
                                        .HasColumnType("bigint");

                                    b2.Property<string>("Building")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("Country")
                                        .HasColumnType("int");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Floor")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Region")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Room")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Street")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("LocationConcertInfoId");

                                    b2.ToTable("ConcertInfo");

                                    b2.WithOwner()
                                        .HasForeignKey("LocationConcertInfoId");
                                });

                            b1.Navigation("Address")
                                .IsRequired();
                        });

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("RemoteApi.Model.Concert", b =>
                {
                    b.Navigation("ConcertInfo");
                });
#pragma warning restore 612, 618
        }
    }
}

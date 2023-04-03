﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.API.Data;

#nullable disable

namespace NZWalks.API.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    [Migration("20230331194733_Seeding Data For Difficulties And Regions")]
    partial class SeedingDataForDifficultiesAndRegions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NZWalks.API.Models.Domain.Difficultys.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a58e359-a485-4676-83a2-86621e63014b"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("9cd98fdd-98a2-4ebd-be3b-c81efdbef18c"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("805055d0-3d4f-4038-be19-a5f4fba44457"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Regions.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RegionImgUrl")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0ccefb3b-08e0-4f3e-989a-5943bf8333c8"),
                            Code = "JPN",
                            Name = "Japan",
                            RegionImgUrl = "https://images.pexels.com/photos/1440476/pexels-photo-1440476.jpeg"
                        },
                        new
                        {
                            Id = new Guid("8a893678-c59a-4a54-9e8f-b4261dba5625"),
                            Code = "WJAV",
                            Name = "West Java",
                            RegionImgUrl = "https://images.pexels.com/photos/2916337/pexels-photo-2916337.jpeg"
                        },
                        new
                        {
                            Id = new Guid("f78b61d2-4931-4628-9de8-ea2c26e9f9bc"),
                            Code = "NTL",
                            Name = "Northland"
                        },
                        new
                        {
                            Id = new Guid("8c2e406e-1cf4-4a63-8366-8324293c63ab"),
                            Code = "BOP",
                            Name = "Bay Of Plenty"
                        },
                        new
                        {
                            Id = new Guid("d96cad25-1fa5-4eed-888b-125a3b06f09d"),
                            Code = "WGN",
                            Name = "Wellington",
                            RegionImgUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },
                        new
                        {
                            Id = new Guid("51aaf94f-b26d-46d0-8cc5-ffbfd9c742bd"),
                            Code = "NSN",
                            Name = "Nelson",
                            RegionImgUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walks.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("char(36)");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("WalksImgUrl")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walks.Walk", b =>
                {
                    b.HasOne("NZWalks.API.Models.Domain.Difficultys.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.API.Models.Domain.Regions.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
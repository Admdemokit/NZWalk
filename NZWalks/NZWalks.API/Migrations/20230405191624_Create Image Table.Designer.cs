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
    [Migration("20230405191624_Create Image Table")]
    partial class CreateImageTable
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
                            Id = new Guid("43e9d1f2-d592-4497-80ff-522a77e30e54"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("8ab164c2-ff37-425f-8e36-8cf030d87f68"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("28759065-b641-498b-a5d8-a6a083c88db0"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Imaging.Imagess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("FileDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("FileSizeinByte")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Imagesses");
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
                            Id = new Guid("3817c97a-c2ff-4af9-8ba8-78ceff525b83"),
                            Code = "JPN",
                            Name = "Japan",
                            RegionImgUrl = "https://images.pexels.com/photos/1440476/pexels-photo-1440476.jpeg"
                        },
                        new
                        {
                            Id = new Guid("5156b760-0a84-4ed9-875c-ba145d9daa38"),
                            Code = "WJAV",
                            Name = "West Java",
                            RegionImgUrl = "https://images.pexels.com/photos/2916337/pexels-photo-2916337.jpeg"
                        },
                        new
                        {
                            Id = new Guid("78e766be-47f7-4cc7-ba7d-81a42ea988f1"),
                            Code = "NTL",
                            Name = "Northland"
                        },
                        new
                        {
                            Id = new Guid("281f65bc-91ca-44df-9702-9642068ba903"),
                            Code = "BOP",
                            Name = "Bay Of Plenty"
                        },
                        new
                        {
                            Id = new Guid("92358852-e60d-4f22-8a35-07a810d1c499"),
                            Code = "WGN",
                            Name = "Wellington",
                            RegionImgUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },
                        new
                        {
                            Id = new Guid("874ae97f-d6f3-47d7-946f-49405cecbb3f"),
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

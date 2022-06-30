﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vivastreet.Data;

#nullable disable

namespace Vivastreet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220630145503_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Vivastreet.Models.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AddvertOTheWeek")
                        .HasColumnType("bit");

                    b.Property<bool>("ClassicAdvert")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostCode")
                        .HasColumnType("int");

                    b.Property<bool>("PremierBanner")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowPhoneNumber")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("Vivastreet.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<int>("DisplayOder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Vivastreet.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<string>("Fair")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Good")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Perfect")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("Vivastreet.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Chinese")
                        .HasColumnType("bit");

                    b.Property<bool>("English")
                        .HasColumnType("bit");

                    b.Property<bool>("French")
                        .HasColumnType("bit");

                    b.Property<bool>("German")
                        .HasColumnType("bit");

                    b.Property<bool>("Italian")
                        .HasColumnType("bit");

                    b.Property<bool>("Other")
                        .HasColumnType("bit");

                    b.Property<bool>("Portugese")
                        .HasColumnType("bit");

                    b.Property<bool>("Russian")
                        .HasColumnType("bit");

                    b.Property<bool>("Spanish")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Langauges");
                });

            modelBuilder.Entity("Vivastreet.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<string>("Durability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Vivastreet.Models.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("Delivery")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("LocalPickUp")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("Vivastreet.Models.SelectAge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.ToTable("selectAges");
                });

            modelBuilder.Entity("Vivastreet.Models.ServiceOffered", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Delivery")
                        .HasColumnType("bit");

                    b.Property<bool>("Instalation")
                        .HasColumnType("bit");

                    b.Property<bool>("Pickup")
                        .HasColumnType("bit");

                    b.Property<bool>("SelectAll")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ServiceOffereds");
                });

            modelBuilder.Entity("Vivastreet.Models.Category", b =>
                {
                    b.HasOne("Vivastreet.Models.Advertisement", "Advertisement")
                        .WithMany("Categories")
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");
                });

            modelBuilder.Entity("Vivastreet.Models.Condition", b =>
                {
                    b.HasOne("Vivastreet.Models.Advertisement", "Advertisement")
                        .WithMany("Conditions")
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");
                });

            modelBuilder.Entity("Vivastreet.Models.Material", b =>
                {
                    b.HasOne("Vivastreet.Models.Advertisement", "Advertisement")
                        .WithMany("Materials")
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");
                });

            modelBuilder.Entity("Vivastreet.Models.SelectAge", b =>
                {
                    b.HasOne("Vivastreet.Models.Advertisement", "Advertisement")
                        .WithMany("Advertisements")
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");
                });

            modelBuilder.Entity("Vivastreet.Models.Advertisement", b =>
                {
                    b.Navigation("Advertisements");

                    b.Navigation("Categories");

                    b.Navigation("Conditions");

                    b.Navigation("Materials");
                });
#pragma warning restore 612, 618
        }
    }
}

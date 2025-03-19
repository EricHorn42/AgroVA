﻿// <auto-generated />
using System;
using AgroVA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgroVA.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgroVA.Domain.Entities.Annotation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FarmerId")
                        .HasColumnType("int");

                    b.Property<int>("HarvestId")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateOnly>("Timestamp")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("FarmerId");

                    b.HasIndex("HarvestId");

                    b.ToTable("Annotations");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Farmer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id");

                    b.ToTable("Farmers");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Harvest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Harvests");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.HuskPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HarvestId")
                        .HasColumnType("int");

                    b.Property<decimal>("Percent")
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.Property<decimal>("Price")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<DateOnly>("Timestamp")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("HarvestId");

                    b.ToTable("HuskPrices");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Load", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("DryWeight")
                        .HasPrecision(8, 3)
                        .HasColumnType("decimal(8,3)");

                    b.Property<int>("FarmerId")
                        .HasColumnType("int");

                    b.Property<decimal?>("GreenWeight")
                        .HasPrecision(8, 3)
                        .HasColumnType("decimal(8,3)");

                    b.Property<int>("HarvestId")
                        .HasColumnType("int");

                    b.Property<long>("Invoice")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Register")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Timestamp")
                        .HasColumnType("date");

                    b.Property<decimal?>("WholePercent")
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.HasKey("Id");

                    b.HasIndex("FarmerId");

                    b.HasIndex("HarvestId");

                    b.ToTable("Loads");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Promissory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FarmerId")
                        .HasColumnType("int");

                    b.Property<int>("HarvestId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Timestamp")
                        .HasColumnType("date");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FarmerId");

                    b.HasIndex("HarvestId");

                    b.ToTable("Promissories");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FarmerId")
                        .HasColumnType("int");

                    b.Property<int>("HarvestId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Timestamp")
                        .HasColumnType("date");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FarmerId");

                    b.HasIndex("HarvestId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Annotation")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("FarmerId")
                        .HasColumnType("int");

                    b.Property<int?>("FarmerId1")
                        .HasColumnType("int");

                    b.Property<int>("HarvestId")
                        .HasColumnType("int");

                    b.Property<int?>("HarvestId1")
                        .HasColumnType("int");

                    b.Property<decimal>("Percent")
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("Person")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Value")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("FarmerId");

                    b.HasIndex("FarmerId1");

                    b.HasIndex("HarvestId");

                    b.HasIndex("HarvestId1");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Annotation", b =>
                {
                    b.HasOne("AgroVA.Domain.Entities.Farmer", "Farmer")
                        .WithMany("Annotations")
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroVA.Domain.Entities.Harvest", "Harvest")
                        .WithMany("Annotations")
                        .HasForeignKey("HarvestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farmer");

                    b.Navigation("Harvest");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.HuskPrice", b =>
                {
                    b.HasOne("AgroVA.Domain.Entities.Harvest", "Harvest")
                        .WithMany("HuskPrices")
                        .HasForeignKey("HarvestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Harvest");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Load", b =>
                {
                    b.HasOne("AgroVA.Domain.Entities.Farmer", "Farmer")
                        .WithMany("Loads")
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroVA.Domain.Entities.Harvest", "Harvest")
                        .WithMany("Loads")
                        .HasForeignKey("HarvestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farmer");

                    b.Navigation("Harvest");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Promissory", b =>
                {
                    b.HasOne("AgroVA.Domain.Entities.Farmer", "Farmer")
                        .WithMany("Promissories")
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroVA.Domain.Entities.Harvest", "Harvest")
                        .WithMany("Promissories")
                        .HasForeignKey("HarvestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farmer");

                    b.Navigation("Harvest");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Receipt", b =>
                {
                    b.HasOne("AgroVA.Domain.Entities.Farmer", "Farmer")
                        .WithMany("Receipts")
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroVA.Domain.Entities.Harvest", "Harvest")
                        .WithMany("Receipts")
                        .HasForeignKey("HarvestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farmer");

                    b.Navigation("Harvest");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Rent", b =>
                {
                    b.HasOne("AgroVA.Domain.Entities.Farmer", "Farmer")
                        .WithMany()
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroVA.Domain.Entities.Farmer", null)
                        .WithMany("Rents")
                        .HasForeignKey("FarmerId1");

                    b.HasOne("AgroVA.Domain.Entities.Harvest", "Harvest")
                        .WithMany()
                        .HasForeignKey("HarvestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroVA.Domain.Entities.Harvest", null)
                        .WithMany("Rents")
                        .HasForeignKey("HarvestId1");

                    b.Navigation("Farmer");

                    b.Navigation("Harvest");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Farmer", b =>
                {
                    b.Navigation("Annotations");

                    b.Navigation("Loads");

                    b.Navigation("Promissories");

                    b.Navigation("Receipts");

                    b.Navigation("Rents");
                });

            modelBuilder.Entity("AgroVA.Domain.Entities.Harvest", b =>
                {
                    b.Navigation("Annotations");

                    b.Navigation("HuskPrices");

                    b.Navigation("Loads");

                    b.Navigation("Promissories");

                    b.Navigation("Receipts");

                    b.Navigation("Rents");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using XPhone.Infrastructure;

#nullable disable

namespace XPhone.Infra.Migrations
{
    [DbContext(typeof(XPhoneDbContext))]
    [Migration("20240617105117_dbstcok6")]
    partial class dbstcok6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmartPhone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Avaiable")
                        .HasColumnType("boolean");

                    b.Property<double>("Core")
                        .HasColumnType("double precision");

                    b.Property<int>("Memory")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("OperationalSystem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<Guid>("StockId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("SmartPhones");
                });

            modelBuilder.Entity("Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("stockName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("XPhone.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Fine")
                        .HasColumnType("boolean");

                    b.Property<double>("FineAmount")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("XPhone.Domain.Entities.Rent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Devolution")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("RentAmount")
                        .HasColumnType("double precision");

                    b.Property<Guid>("SmartPhoneId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("SmartPhoneId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("XPhone.Domain.Entities.Return", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Condition")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RentId")
                        .IsUnique();

                    b.ToTable("Returns");
                });

            modelBuilder.Entity("SmartPhone", b =>
                {
                    b.HasOne("Stock", "Stock")
                        .WithMany("Phones")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("XPhone.Domain.Entities.Rent", b =>
                {
                    b.HasOne("XPhone.Domain.Entities.Client", "Client")
                        .WithMany("Rents")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartPhone", "SmartPhone")
                        .WithMany()
                        .HasForeignKey("SmartPhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("SmartPhone");
                });

            modelBuilder.Entity("XPhone.Domain.Entities.Return", b =>
                {
                    b.HasOne("XPhone.Domain.Entities.Rent", "Rent")
                        .WithOne("Return")
                        .HasForeignKey("XPhone.Domain.Entities.Return", "RentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rent");
                });

            modelBuilder.Entity("Stock", b =>
                {
                    b.Navigation("Phones");
                });

            modelBuilder.Entity("XPhone.Domain.Entities.Client", b =>
                {
                    b.Navigation("Rents");
                });

            modelBuilder.Entity("XPhone.Domain.Entities.Rent", b =>
                {
                    b.Navigation("Return")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Versta.Landing.Infrastructure.Persistence;

#nullable disable

namespace Versta.Landing.Infrastructure.Migrations
{
    [DbContext(typeof(OrdersDbContext))]
    [Migration("20250701010534_Added Orders table")]
    partial class AddedOrderstable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Versta.Landing.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("PackagePickupDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("package_pickup_date");

                    b.Property<decimal>("PackageWeightKg")
                        .HasColumnType("numeric")
                        .HasColumnName("package_weight_kg");

                    b.Property<string>("ReceiverAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("receiver_address");

                    b.Property<string>("ReceiverCity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("receiver_city");

                    b.Property<string>("SenderAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sender_address");

                    b.Property<string>("SenderCity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sender_city");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

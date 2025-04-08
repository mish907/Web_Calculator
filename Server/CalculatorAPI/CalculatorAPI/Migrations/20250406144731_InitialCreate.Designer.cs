﻿// <auto-generated />
using CalculatorAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CalculatorAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20250406144731_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CalculatorAPI.Models.Calculator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("FirstNumber")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Operator")
                        .HasColumnType("int");

                    b.Property<decimal>("Result")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SecondNumber")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("storedCalculation");
                });
#pragma warning restore 612, 618
        }
    }
}

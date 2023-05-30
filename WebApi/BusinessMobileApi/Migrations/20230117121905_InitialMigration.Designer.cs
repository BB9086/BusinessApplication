﻿// <auto-generated />
using BusinessMobileApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusinessMobileApi.Migrations
{
    [DbContext(typeof(BusinessDBContext))]
    [Migration("20230117121905_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BusinessMobileApi.Models.Store", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("connected")
                        .HasColumnType("int");

                    b.Property<string>("ip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.Property<decimal>("paidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("seller")
                        .HasColumnType("int");

                    b.Property<decimal>("unpaidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
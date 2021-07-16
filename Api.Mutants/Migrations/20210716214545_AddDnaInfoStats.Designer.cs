﻿// <auto-generated />
using System;
using Api.Mutants.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Mutants.Migrations
{
    [DbContext(typeof(MutantsContext))]
    [Migration("20210716214545_AddDnaInfoStats")]
    partial class AddDnaInfoStats
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Mutants.Models.Stat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dna")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Dna");

                    b.Property<bool>("IsMutant")
                        .HasColumnType("bit")
                        .HasColumnName("IsMutant");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime")
                        .HasColumnName("RequestDate");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}

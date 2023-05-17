﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvestApi.Migrations
{
    [DbContext(typeof(InvestApiContext))]
    partial class InvestApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("InvestApi.Models.Ordem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataOrdem")
                        .HasColumnType("TEXT");

                    b.Property<int>("quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("tickler")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Ordem");
                });
#pragma warning restore 612, 618
        }
    }
}
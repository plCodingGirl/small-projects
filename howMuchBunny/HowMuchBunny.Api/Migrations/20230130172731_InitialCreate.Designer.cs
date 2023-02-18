﻿// <auto-generated />
using System;
using HowMuchBunny.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HowMuchBunny.Api.Migrations
{
    [DbContext(typeof(BunnyWeightContext))]
    [Migration("20230130172731_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Bunny", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bunnies");
                });

            modelBuilder.Entity("Weight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BunnyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BunnyId");

                    b.ToTable("Weights");
                });

            modelBuilder.Entity("Weight", b =>
                {
                    b.HasOne("Bunny", null)
                        .WithMany("Weight")
                        .HasForeignKey("BunnyId");
                });

            modelBuilder.Entity("Bunny", b =>
                {
                    b.Navigation("Weight");
                });
#pragma warning restore 612, 618
        }
    }
}

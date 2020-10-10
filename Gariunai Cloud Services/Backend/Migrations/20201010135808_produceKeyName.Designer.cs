﻿// <auto-generated />
using System;
using Gariunai_Cloud_Services.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gariunai_Cloud_Services.Migrations
{
    [DbContext(typeof(DataAccess))]
    [Migration("20201010135808_produceKeyName")]
    partial class produceKeyName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gariunai_Cloud_Services.Entities.Password", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserName");

                    b.HasIndex("UserName1");

                    b.ToTable("Passwords");
                });

            modelBuilder.Entity("Gariunai_Cloud_Services.Entities.Produce", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("ShopId");

                    b.ToTable("Produce");
                });

            modelBuilder.Entity("Gariunai_Cloud_Services.Entities.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerName");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("Gariunai_Cloud_Services.Entities.User", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Gariunai_Cloud_Services.Entities.Password", b =>
                {
                    b.HasOne("Gariunai_Cloud_Services.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserName1");
                });

            modelBuilder.Entity("Gariunai_Cloud_Services.Entities.Produce", b =>
                {
                    b.HasOne("Gariunai_Cloud_Services.Entities.Shop", null)
                        .WithMany("Produce")
                        .HasForeignKey("ShopId");
                });

            modelBuilder.Entity("Gariunai_Cloud_Services.Entities.Shop", b =>
                {
                    b.HasOne("Gariunai_Cloud_Services.Entities.User", "Owner")
                        .WithMany("Businesses")
                        .HasForeignKey("OwnerName");
                });
#pragma warning restore 612, 618
        }
    }
}
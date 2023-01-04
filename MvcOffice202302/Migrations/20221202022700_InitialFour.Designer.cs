﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcOffice.Data;

#nullable disable

namespace MvcOffice.Migrations
{
    [DbContext(typeof(MvcOfficeContext))]
    [Migration("20221202022700_InitialFour")]
    partial class InitialFour
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MvcOffice.Models.KengicAspNetCore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("KengicAspNetCore");
                });

            modelBuilder.Entity("MvcOffice.Models.KengicAspnetcorePictureSum", b =>
                {
                    b.Property<string>("KengicAspnetcorePictureSumId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("detail2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("srcaddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KengicAspnetcorePictureSumId");

                    b.ToTable("KengicAspnetcorePictureSum");
                });

            modelBuilder.Entity("MvcOffice.Models.PictureSum", b =>
                {
                    b.Property<string>("PictureSumId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("detail2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("srcaddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PictureSumId");

                    b.ToTable("PictureSum");
                });

            modelBuilder.Entity("MvcOffice.Models.Uniquedoor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Uniquedoor");
                });
#pragma warning restore 612, 618
        }
    }
}

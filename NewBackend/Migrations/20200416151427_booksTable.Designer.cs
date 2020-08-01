﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewBackend;

namespace NewBackend.Migrations
{
    [DbContext(typeof(NewBackendDbContext))]
    [Migration("20200416151427_booksTable")]
    partial class booksTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewBackend.Author", b =>
                {
                    b.Property<int>("IdAuthor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.Property<string>("Surname")
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.HasKey("IdAuthor");

                    b.ToTable("Authors","db");
                });

            modelBuilder.Entity("NewBackend.Book", b =>
                {
                    b.Property<int>("IdBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar")
                        .HasMaxLength(500);

                    b.Property<string>("Editor")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasMaxLength(50);

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasMaxLength(50);

                    b.Property<int?>("PublishingYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasMaxLength(50);

                    b.HasKey("IdBook");

                    b.ToTable("Books","db");
                });
#pragma warning restore 612, 618
        }
    }
}
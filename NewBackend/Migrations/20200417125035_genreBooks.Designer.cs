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
    [Migration("20200417125035_genreBooks")]
    partial class genreBooks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewBackend.Models.Author", b =>
                {
                    b.Property<int>("IdAuthor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.Property<string>("Surname")
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.HasKey("IdAuthor");

                    b.ToTable("Authors","db");
                });

            modelBuilder.Entity("NewBackend.Models.Book", b =>
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

                    b.Property<int>("IdGenre")
                        .HasColumnType("int");

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

                    b.HasIndex("IdGenre");

                    b.ToTable("Books","db");
                });

            modelBuilder.Entity("NewBackend.Models.FavouritesUserBooks", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdBook")
                        .HasColumnType("int");

                    b.HasKey("IdUser", "IdBook");

                    b.HasIndex("IdBook");

                    b.ToTable("Favourites","db");
                });

            modelBuilder.Entity("NewBackend.Models.Genre", b =>
                {
                    b.Property<int>("IdGenre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.HasKey("IdGenre");

                    b.ToTable("Genres","db");
                });

            modelBuilder.Entity("NewBackend.Models.Loan", b =>
                {
                    b.Property<int>("IdLoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateReturn")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime");

                    b.HasKey("IdLoan");

                    b.ToTable("Loans","db");
                });

            modelBuilder.Entity("NewBackend.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.Property<string>("ImgPath")
                        .HasColumnType("varchar")
                        .HasMaxLength(1000);

                    b.Property<int>("IsAdmin")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.Property<string>("Phone")
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasMaxLength(20);

                    b.HasKey("IdUser");

                    b.ToTable("Users","db");
                });

            modelBuilder.Entity("NewBackend.Models.Book", b =>
                {
                    b.HasOne("NewBackend.Models.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("IdGenre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewBackend.Models.FavouritesUserBooks", b =>
                {
                    b.HasOne("NewBackend.Models.Book", "Book")
                        .WithMany("FavouritesUserBooks")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewBackend.Models.User", "User")
                        .WithMany("FavouritesUserBooks")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

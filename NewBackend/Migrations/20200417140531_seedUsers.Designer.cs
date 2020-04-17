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
    [Migration("20200417140531_seedUsers")]
    partial class seedUsers
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
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Surname")
                        .HasColumnType("varchar(20)");

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
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Editor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdAuthor")
                        .HasColumnType("int");

                    b.Property<int>("IdGenre")
                        .HasColumnType("int");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("PublishingYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdBook");

                    b.HasIndex("IdAuthor");

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
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdGenre");

                    b.ToTable("Genres","db");
                });

            modelBuilder.Entity("NewBackend.Models.Loan", b =>
                {
                    b.Property<int>("IdLoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateReturn")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IdLoan");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Loans","db");
                });

            modelBuilder.Entity("NewBackend.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("ImgPath")
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("IsAdmin")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdUser");

                    b.ToTable("Users","db");

                    b.HasData(
                        new
                        {
                            IdUser = 1,
                            Address = "Via Roma, 88",
                            Email = "lorena@email.it",
                            ImgPath = "https://source.unsplash.com/EbQRjuEdFcg",
                            IsAdmin = 0,
                            Name = "Lorena",
                            Password = "lorena123",
                            Phone = "1234567890",
                            Surname = "Schirru"
                        },
                        new
                        {
                            IdUser = 2,
                            Address = "Piazza Italia 8",
                            Email = "pino@email.it",
                            ImgPath = "https://source.unsplash.com/4nulm-JUYFo",
                            IsAdmin = 0,
                            Name = "Pino",
                            Password = "pino123",
                            Phone = "333123123",
                            Surname = "Rossi"
                        },
                        new
                        {
                            IdUser = 3,
                            Address = "VIa della liberta 4",
                            Email = "bianchi@email.it",
                            ImgPath = "https://source.unsplash.com/NAdFJtFFlHE",
                            IsAdmin = 0,
                            Name = "Paolo",
                            Password = "bianchi123",
                            Surname = "Bianchi"
                        },
                        new
                        {
                            IdUser = 4,
                            Address = "Via muccarloa",
                            Email = "benvenuto@email.it",
                            ImgPath = "https://source.unsplash.com/2RhlxwRz4yc",
                            IsAdmin = 0,
                            Name = "Simone",
                            Password = "benvenuto123",
                            Phone = "0105345345",
                            Surname = "Benvenuto"
                        });
                });

            modelBuilder.Entity("NewBackend.Models.Book", b =>
                {
                    b.HasOne("NewBackend.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("IdAuthor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("NewBackend.Models.Loan", b =>
                {
                    b.HasOne("NewBackend.Models.Book", "Book")
                        .WithOne("Loan")
                        .HasForeignKey("NewBackend.Models.Loan", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewBackend.Models.User", "User")
                        .WithOne("Loan")
                        .HasForeignKey("NewBackend.Models.Loan", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

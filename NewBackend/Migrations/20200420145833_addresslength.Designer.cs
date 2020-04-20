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
    [Migration("20200420145833_addresslength")]
    partial class addresslength
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
                        .HasColumnType("varchar(1000)");

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

                    b.HasData(
                        new
                        {
                            IdBook = 1,
                            Description = "Esther is a stowaway. She's hidden herself away in the Librarian's book wagon in an attempt to escape the marriage her father has arranged for her--a marriage to the man who was previously engaged to her best friend. Her best friend who she was in love with. Her best friend who was just executed for possession of resistance propaganda.The future American Southwest is full of bandits, fascists, and queer librarian spies on horseback trying to do the right thing.",
                            Editor = "Mondadori",
                            IdAuthor = 3,
                            IdGenre = 1,
                            Isbn = "1250213584",
                            PublishingYear = 2020,
                            Title = "Upright Women Wanted"
                        },
                        new
                        {
                            IdBook = 2,
                            Description = "Today, Facebook is nearly unrecognizable from Zuckerberg's first, modest iteration. It has grown into a tech giant, the largest social media platform and one of the most gargantuan companies in the world, with a valuation of more than $576 billion and almost 3 billion users, including those on its fully owned subsidiaries, Instagram and WhatsApp. There is no denying the power and omnipresence of Facebook in American daily life. And in light of recent controversies surrounding election-influencing fake news accounts, the handling of its users' personal data, and growing discontent with the actions of its founder and CEO, never has the company been more central to the national conversation.",
                            Editor = "InMondadori",
                            IdAuthor = 6,
                            IdGenre = 3,
                            Isbn = "0735213151",
                            PublishingYear = 2020,
                            Title = "Facebook: The Inside Story"
                        },
                        new
                        {
                            IdBook = 3,
                            Description = "L'Orient-Express, il famoso treno che congiunge Parigi con Istanbul, è costretto ad una sosta forzata, bloccato dalla neve. A bordo qualcuno ne approfitta per compiere un efferato delitto, ma, sfortunatamente per l'assassino, tra i passeggeri c'è anche il famoso investigatore belga Hercule Poirot, al quale verranno affidate le indagini. Poirot, in effetti, risolverà il caso, non prima, però, di essersi imbattuto in una sensazionale sorpresa.",
                            Editor = "Mondadori",
                            IdAuthor = 1,
                            IdGenre = 1,
                            Isbn = "8804519045",
                            PublishingYear = 2007,
                            Title = "Assasinio sull'Orient Express"
                        },
                        new
                        {
                            IdBook = 4,
                            Description = "Il volume si propone come una guida graduale e completa al linguaggio C e alla programmazione strutturata e modulare. Particolare attenzione è posta sui principi e sulle tecniche di programmazione, il controllo del flusso di esecuzione, la rappresentazione dei dati, la definizione e l'utilizzo di funzioni e librerie, le strutture dati, le operazioni di ingresso e uscita. Per quando riguarda il C il testo è stato aggiornato allo standard C11. La nuova edizione è anche anche un'introduzione alla programmazione orientata agli oggetti e al linguaggio Objective-C, che permette di programmare le app per iPhone, Ipad e per i computer della Apple. Grande cura è rivolta ai concetti di generalizzazione, classe, oggetto, istanza, ereditarietà e alla",
                            Editor = "McGraw-Hill Education",
                            IdAuthor = 4,
                            IdGenre = 4,
                            Isbn = "9788838665790",
                            PublishingYear = 2013,
                            Title = "Linguaggio C"
                        },
                        new
                        {
                            IdBook = 5,
                            Description = "l Novecento, un secolo che si apre col trauma originario della Grande Guerra e si chiude con le grandi trasformazioni seguite alla caduta del muro di Berlino: è la periodizzazione di questo manuale, che si spinge ad analizzare gli ultimi eventi dei nostri giorni senza rinunciare a una struttura agile, maneggevole e rigorosa, a una scrittura piana e comprensibile, a una strumentazione didattica particolarmente efficace, dalle numerose cartine alle bibliografie ragionate che guidano l’approfondimento dei temi toccati. In questa nuova edizione, fortemente accresciuta e rivista, sono state inserite numerose nuove Parole chiave, indispensabili per focalizzare le principali categorie tematico-concettuali del periodo.",
                            Editor = "Laterza",
                            IdAuthor = 2,
                            IdGenre = 1,
                            Isbn = "9788842087427",
                            PublishingYear = 2018,
                            Title = "Storia contempo"
                        });
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

                    b.HasData(
                        new
                        {
                            IdGenre = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            IdGenre = 2,
                            Name = "Storico"
                        },
                        new
                        {
                            IdGenre = 3,
                            Name = "Saggistica"
                        },
                        new
                        {
                            IdGenre = 4,
                            Name = "Informatica"
                        },
                        new
                        {
                            IdGenre = 5,
                            Name = "Diritto"
                        });
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
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

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

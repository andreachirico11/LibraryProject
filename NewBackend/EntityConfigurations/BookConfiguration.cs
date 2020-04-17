using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBackend.Models;

namespace NewBackend
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        { 
             builder.ToTable("Books", "db");
             builder.HasKey(b => b.IdBook);
             builder.Property(b => b.IdBook)
                    .HasColumnType("int")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            builder.Property(b => b.Title)
                    .HasColumnType("varchar(50)")
                //     .HasMaxLength(50)
                    .IsRequired();
            builder.Property(b => b.Editor)
                    .HasColumnType("varchar(50)")
                //     .HasMaxLength(50)
                    .IsRequired();
            builder.Property(b => b.PublishingYear)
                    .HasColumnType("int");
            builder.Property(b => b.Description)
                    .HasColumnType("varchar(1000)");
                //     .HasMaxLength(50)
                //     .HasMaxLength(500);
            builder.Property(b => b.Isbn)
                    .HasColumnType("varchar(30)")
                //     .HasMaxLength(1)
                    .IsRequired();


            builder.HasData(new Book(1, "Upright Women Wanted","Mondadori",2020,"Esther is a stowaway. She's hidden herself away in the Librarian's book wagon in an attempt to escape the marriage her father has arranged for her--a marriage to the man who was previously engaged to her best friend. Her best friend who she was in love with. Her best friend who was just executed for possession of resistance propaganda.The future American Southwest is full of bandits, fascists, and queer librarian spies on horseback trying to do the right thing.", "1250213584", 1, 3));
            builder.HasData(new Book(2, "Facebook: The Inside Story", "InMondadori", 2020, "Today, Facebook is nearly unrecognizable from Zuckerberg's first, modest iteration. It has grown into a tech giant, the largest social media platform and one of the most gargantuan companies in the world, with a valuation of more than $576 billion and almost 3 billion users, including those on its fully owned subsidiaries, Instagram and WhatsApp. There is no denying the power and omnipresence of Facebook in American daily life. And in light of recent controversies surrounding election-influencing fake news accounts, the handling of its users' personal data, and growing discontent with the actions of its founder and CEO, never has the company been more central to the national conversation.",  "0735213151", 3, 6));
            builder.HasData(new Book(3, "Assasinio sull'Orient Express", "Mondadori", 2007, "L'Orient-Express, il famoso treno che congiunge Parigi con Istanbul, è costretto ad una sosta forzata, bloccato dalla neve. A bordo qualcuno ne approfitta per compiere un efferato delitto, ma, sfortunatamente per l'assassino, tra i passeggeri c'è anche il famoso investigatore belga Hercule Poirot, al quale verranno affidate le indagini. Poirot, in effetti, risolverà il caso, non prima, però, di essersi imbattuto in una sensazionale sorpresa.", "8804519045", 1, 1 ));
            builder.HasData(new Book(4, "Linguaggio C", "McGraw-Hill Education", 2013, "Il volume si propone come una guida graduale e completa al linguaggio C e alla programmazione strutturata e modulare. Particolare attenzione è posta sui principi e sulle tecniche di programmazione, il controllo del flusso di esecuzione, la rappresentazione dei dati, la definizione e l'utilizzo di funzioni e librerie, le strutture dati, le operazioni di ingresso e uscita. Per quando riguarda il C il testo è stato aggiornato allo standard C11. La nuova edizione è anche anche un'introduzione alla programmazione orientata agli oggetti e al linguaggio Objective-C, che permette di programmare le app per iPhone, Ipad e per i computer della Apple. Grande cura è rivolta ai concetti di generalizzazione, classe, oggetto, istanza, ereditarietà e alla", "9788838665790", 4,4 ));
            builder.HasData(new Book(5, "Storia contempo", "Laterza", 2018, "l Novecento, un secolo che si apre col trauma originario della Grande Guerra e si chiude con le grandi trasformazioni seguite alla caduta del muro di Berlino: è la periodizzazione di questo manuale, che si spinge ad analizzare gli ultimi eventi dei nostri giorni senza rinunciare a una struttura agile, maneggevole e rigorosa, a una scrittura piana e comprensibile, a una strumentazione didattica particolarmente efficace, dalle numerose cartine alle bibliografie ragionate che guidano l’approfondimento dei temi toccati. In questa nuova edizione, fortemente accresciuta e rivista, sono state inserite numerose nuove Parole chiave, indispensabili per focalizzare le principali categorie tematico-concettuali del periodo.", "9788842087427", 1 ,2));

        }
    }
}
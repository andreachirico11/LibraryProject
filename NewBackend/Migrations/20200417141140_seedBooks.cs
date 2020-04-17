using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class seedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "db",
                table: "Books",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "db",
                table: "Books",
                columns: new[] { "IdBook", "Description", "Editor", "IdAuthor", "IdGenre", "Isbn", "PublishingYear", "Title" },
                values: new object[,]
                {
                    { 1, "Esther is a stowaway. She's hidden herself away in the Librarian's book wagon in an attempt to escape the marriage her father has arranged for her--a marriage to the man who was previously engaged to her best friend. Her best friend who she was in love with. Her best friend who was just executed for possession of resistance propaganda.The future American Southwest is full of bandits, fascists, and queer librarian spies on horseback trying to do the right thing.", "Mondadori", 3, 1, "1250213584", 2020, "Upright Women Wanted" },
                    { 2, "Today, Facebook is nearly unrecognizable from Zuckerberg's first, modest iteration. It has grown into a tech giant, the largest social media platform and one of the most gargantuan companies in the world, with a valuation of more than $576 billion and almost 3 billion users, including those on its fully owned subsidiaries, Instagram and WhatsApp. There is no denying the power and omnipresence of Facebook in American daily life. And in light of recent controversies surrounding election-influencing fake news accounts, the handling of its users' personal data, and growing discontent with the actions of its founder and CEO, never has the company been more central to the national conversation.", "InMondadori", 6, 3, "0735213151", 2020, "Facebook: The Inside Story" },
                    { 3, "L'Orient-Express, il famoso treno che congiunge Parigi con Istanbul, è costretto ad una sosta forzata, bloccato dalla neve. A bordo qualcuno ne approfitta per compiere un efferato delitto, ma, sfortunatamente per l'assassino, tra i passeggeri c'è anche il famoso investigatore belga Hercule Poirot, al quale verranno affidate le indagini. Poirot, in effetti, risolverà il caso, non prima, però, di essersi imbattuto in una sensazionale sorpresa.", "Mondadori", 1, 1, "8804519045", 2007, "Assasinio sull'Orient Express" },
                    { 4, "Il volume si propone come una guida graduale e completa al linguaggio C e alla programmazione strutturata e modulare. Particolare attenzione è posta sui principi e sulle tecniche di programmazione, il controllo del flusso di esecuzione, la rappresentazione dei dati, la definizione e l'utilizzo di funzioni e librerie, le strutture dati, le operazioni di ingresso e uscita. Per quando riguarda il C il testo è stato aggiornato allo standard C11. La nuova edizione è anche anche un'introduzione alla programmazione orientata agli oggetti e al linguaggio Objective-C, che permette di programmare le app per iPhone, Ipad e per i computer della Apple. Grande cura è rivolta ai concetti di generalizzazione, classe, oggetto, istanza, ereditarietà e alla", "McGraw-Hill Education", 4, 4, "9788838665790", 2013, "Linguaggio C" },
                    { 5, "l Novecento, un secolo che si apre col trauma originario della Grande Guerra e si chiude con le grandi trasformazioni seguite alla caduta del muro di Berlino: è la periodizzazione di questo manuale, che si spinge ad analizzare gli ultimi eventi dei nostri giorni senza rinunciare a una struttura agile, maneggevole e rigorosa, a una scrittura piana e comprensibile, a una strumentazione didattica particolarmente efficace, dalle numerose cartine alle bibliografie ragionate che guidano l’approfondimento dei temi toccati. In questa nuova edizione, fortemente accresciuta e rivista, sono state inserite numerose nuove Parole chiave, indispensabili per focalizzare le principali categorie tematico-concettuali del periodo.", "Laterza", 2, 1, "9788842087427", 2018, "Storia contempo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "db",
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "db",
                table: "Books",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);
        }
    }
}

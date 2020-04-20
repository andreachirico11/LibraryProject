public class AuthorDTO
{
    public long IdAuthor { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public AuthorDTO() {}
    // public AuthorDTO(Authors author) 
    // {
    //     this.IdAuthor = author.IdAuthor;
    //     this.Name = author.Name;
    //     this.Surname = author.Surname;
    // }
}
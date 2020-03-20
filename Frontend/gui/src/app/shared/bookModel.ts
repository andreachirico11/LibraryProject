export class BookModel {
  public idBook: number;
  public title: string;
  public editor: string;
  public publishingYear : Date;
  public idGenre: number;
  public idAuthor: number;
  public description: string;
  public isbn: string;
  public idAuthorNavigation: number;
  public idGenreNavigation: number;
  public loans: string []

  constructor(
    IdBook: number,
    Title: string,
    Editor: string,
    PublishingYear : Date,
    IdGenre: number,
    IdAuthor: number,
    Description: string,
    Isbn: string,
    IdAuthorNavigation: number,
    IdGenreNavigation: number,
    Loans: string []
  ) {
    this.idBook = IdBook
    this.title = Title
    this.editor = Editor
    this.publishingYear = PublishingYear
    this.idGenre = IdGenre
    this.idAuthor = IdAuthor
    this.description = Description
    this.isbn = Isbn
    this.idAuthorNavigation = IdAuthorNavigation
    this.idGenreNavigation = IdGenreNavigation
    this.loans = Loans
  }
}

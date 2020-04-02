export class BookModel {
  constructor(
  public idBook: number,
  public title: string,
  public editor: string,
  public publishingYear : number,
  public genre : number,
  public author: string,
  public description: string,
  public isbn: number,
  public loans: string [],
  public imagePath: string,
  public isFav?: boolean,
  public isLoaned?: boolean
  ) {}

}

// export class BookModelWithFavAndLoans {
//   constructor(
//     public bookInfo : BookModel,
//     public isFav: boolean,
//     public isLoaned? : boolean
//     ) {}
// }

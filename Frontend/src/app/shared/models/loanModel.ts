export class Loan {
  constructor(
    public idUser: number,
    public idBook: number,
    public bookTitle: string,
    public dateStart: Date,
    public isbn: string,
    public daysLeft?: number,
    public userName?: string,
    public dateReturn?: Date
  ) {}
}

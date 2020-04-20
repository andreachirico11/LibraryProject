import { BookModel } from './bookModel';

export class User {
  constructor(
    public email: string,
    public password: string,
    // public token?: string,
    public isAdmin: boolean,
    public name: string,
    public surname: string,
    public idUser?: number,
    public phone?: number,
    public address?: string,
    public imgPath?: string,
    public favourites?: BookModel[],
    public borrowed?: number[],
  ) {}
}

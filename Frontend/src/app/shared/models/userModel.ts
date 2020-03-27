export class User {
  constructor(
    public email: string,
    public password: string,
    public token: string,
    public isAdmin: boolean,
    public name: string,
    public surname: string,
    public idUser?: number,
    public phoneNumber?: number,
    public adress?: string,
    public imgPath?: string,
    public favourites?: string[],
    public borrowed?: string[],
  ) {}
}

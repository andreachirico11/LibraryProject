export class User {
  constructor(
    public email: string,
    public password: string,
    private _token: string,
    private _isAdmin: boolean
  ) {}
  get token() {
    return  this._token;
  }
  get isAdmin() {
    return  this._isAdmin;
  }
}

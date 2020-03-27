import { TestBed } from "@angular/core/testing";
import {
  HttpClientTestingModule,
  HttpTestingController
} from "@angular/common/http/testing";
import { dbService } from "./dbActions.service";
import { environment } from "../../environments/environment";
import * as mocks from "./models/mocks";
import { HttpHeaders } from "@angular/common/http";
import { BookModel } from "./models/bookModel";

let databaseService: dbService;
let httpTestingController: HttpTestingController;

beforeEach(() => {
  TestBed.configureTestingModule({
    imports: [HttpClientTestingModule],
    providers: [dbService]
  });
  databaseService = TestBed.get(dbService);
  httpTestingController = TestBed.get(HttpTestingController);
});

it("should get the right data", () => {
  databaseService.getAllBooks().subscribe(res => {
    expect(res).toBeTruthy();
    expect(res[0].title).toBe(mocks.mockBooksDbJson[0].title);
    expect(res[2].title).toBe(mocks.mockBooksDbJson[2].title);
    expect(res[3].title).toBe(mocks.mockBooksDbJson[3].title);
    expect(res[4].title).toBe(mocks.mockBooksDbJson[4].title);
  });

  const req = httpTestingController.expectOne(
    environment.connectionStr + "books"
  );
  req.flush(mocks.mockBooksDbJson);

  httpTestingController.verify();
});

it("should get a precise book", () => {
  let id = 1;
  databaseService.getBookById(id).subscribe(res => {
    expect(res.editor).toBe(mocks.mockBooksDbJsonPost.editor);
  });
  const req = httpTestingController.expectOne(
    environment.connectionStr + "books/" + id
  );
  req.flush(mocks.mockBooksDbJsonPost);
  httpTestingController.verify();
});

it("should send the right data", () => {
  databaseService.postBook(mocks.mockBook).subscribe((res: BookModel) => {
    expect(res).toEqual(mocks.mockBooksDbJsonPost);
  });
  const req = httpTestingController.expectOne(
    environment.connectionStr + "books"
  );
  expect(req.request.method).toEqual("POST");
  req.flush(mocks.mockBooksDbJsonPost);
});

it('should change an exhisting book', () => {
  let idToChange;
  let modifiedBook = mocks.mockBook;
  modifiedBook.title = 'felice felicità';

  databaseService.putBook(modifiedBook, idToChange).subscribe( (res: BookModel) => {
    expect(res.title).toBe(modifiedBook.title);
  });
  const req = httpTestingController.expectOne(
    environment.connectionStr + "books/" + idToChange
  );
  expect(req.request.method).toEqual("PUT");
  req.flush(modifiedBook);
});

it('should delete books', () => {
  let idToDelete = 2;

  databaseService.deleteBookById(idToDelete).subscribe( (res: BookModel[]) => {
  });
  const req = httpTestingController.expectOne(
    environment.connectionStr + "books/" + idToDelete
  );
  expect(req.request.method).toEqual("DELETE");
  req.flush(mocks.mockBooksDbJson);
});

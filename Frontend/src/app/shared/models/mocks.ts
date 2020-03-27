import { BookModel } from './bookModel';
import { User } from './userModel';

export const mockBooksDbJson = [
  {
    "idBook": 1,
    "title": "Storia antica L'Ottocento",
    "editor": "Laterza",
    "publishingYear": null,
    "idGenre": 2,
    "idAuthor": 3,
    "description": null,
    "isbn": null,
    "idAuthorNavigation": null,
    "idGenreNavigation": null,
     "loans": []
  },
  {
      "idBook": 2,
      "title": "Storia moderna 1492-1848",
      "editor": "feltrinelli",
      "publishingYear": 2016,
      "idGenre": 2,
      "idAuthor": 2,
      "description": null,
      "isbn": null,
      "idAuthorNavigation": null,
      "idGenreNavigation": null,
      "loans": []
  },
  {
      "idBook": 3,
      "title": "Assasinio sull'Orient Express",
      "editor": "Feltrinelli",
      "publishingYear": 0,
      "idGenre": 1,
      "idAuthor": 1,
      "description": null,
      "isbn": null,
      "idAuthorNavigation": null,
      "idGenreNavigation": null,
      "loans": []
  },
  {
      "idBook": 4,
      "title": "Linguaggio C",
      "editor": "McGraw-Hill Education",
      "publishingYear": 2013,
      "idGenre": 4,
      "idAuthor": 4,
      "description": null,
        "isbn": null,
      "idAuthorNavigation": null,
      "idGenreNavigation": null,
      "loans": []
  },
  {
      "idBook": 5,
      "title": "Storia contempo",
      "editor": "Laterz",
      "publishingYear": null,
      "idGenre": 1,
      "idAuthor": 2,
      "description": null,
      "isbn": null,
      "idAuthorNavigation": null,
      "idGenreNavigation": null,
      "loans": []
  }
];
export const mockBooksDbJsonPost = {
  "idBook": 6,
  "title": "Storia antica L'Ottocento",
  "editor": "Laterza",
  "publishingYear": null,
  "idGenre": 2,
  "idAuthor": 3,
  "description": null,
  "isbn": null,
  "idAuthorNavigation": null,
  "idGenreNavigation": null,
   "loans": []
}
export const mockBook = new BookModel(
  7,
  'guerra e pace',
  'giovanni',
  null,
  3,
  'ggasgs',
  null,
  null,
  null,
  null
);

export const Users = [
  new User(
    "giuseppe@email.it",
    "giuseppe123",
    "abcdefg",
    false,
    "giuseppe",
    "giuseppi",
    1,
    3470000,
    "via giuseppe 123 genova",
    "https://source.unsplash.com/tD1XD54mx8w/600x600",
    [],
    []
  ),
  new User(
    "carlo@email.it",
    "carlo123",
    "gklmno",
    true,
    "carlo",
    "carli",
    2,
    34704582039,
    "via carlo 1 genova",
    "https://source.unsplash.com/_cvwXhGqG-o/600x600",
    [],
    []
  )
];

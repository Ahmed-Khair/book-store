using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_store.Models.repositories
{
    public class Bookrepository : repositoriesInterface<Book>
    {
        List<Book> books;
        public Bookrepository()
        {
            books = new List<Book>()
            {
               new Book
               {
                   Idbook=1,
                   Title="welcome to core",
                   Description="vergooood",
                   imageurl="aa.JPG",
                   Auther=new Auther(){Id_auther=1 }//add it because null exception error

               },
               new Book
               {
                   Idbook=2,
                   Title="welcome to mvc",
                   Description="vergooood2",
                    imageurl="bb.jpg",
                  Auther=new Auther(){Id_auther=3 }
               },
               new Book
               {
                   Idbook=3,
                   Title="welcome to C#",
                   Description="vergooood3",
                    imageurl="cc.PNG",
                   Auther=new Auther(){Id_auther=3 }
               }

            };
        }
        public void add(Book entity)
        {
            entity.Idbook = books.Max(b => b.Idbook )+ 1;// to add new book add automatically id
            books.Add(entity);
        }

        public void delete(int id)
        {
            // var book = books.SingleOrDefault(b => b.Idbook == id); repeted in find method
            var book = find(id);
            books.Remove(book);
        }

        public Book find(int id)
        {
            var book = books.SingleOrDefault(b => b.Idbook == id);
            return book;
        }

        public IList<Book> list()
        {
            return books;
        }

        public List<Book> search(string term)
        {

            return books.Where(a => a.Title.Contains(term)).ToList();
        }

        public void update(int id, Book newbook)
        {
            // var book = books.SingleOrDefault(b => b.Idbook == id);  repeted in find method
            var book = find(id);
            book.Title = newbook.Title;
            book.Description = newbook.Description;
            book.Auther = newbook.Auther;
           book.imageurl=newbook.imageurl;
        }

    }
}

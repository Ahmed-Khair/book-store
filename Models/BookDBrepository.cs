using book_store.Models.repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_store.Models
{
    public class BookDBrepository : repositoriesInterface<Book>
    {
        private readonly Dbcontxt db;

        public BookDBrepository(Dbcontxt db)
        {
            this.db = db;
        }
        public void add(Book entity)
        {
            //entity.Idbook = books.Max(b => b.Idbook) + 1;// to add new book add automatically id
            //books.Add(entity);
           db.books.Add(entity);
            db.SaveChanges();
        }

        public void delete(int id)
        {
            // var book = books.SingleOrDefault(b => b.Idbook == id); repeted in find method
            var book = find(id);
            db.books.Remove(book);
            db.SaveChanges();
        }

        public Book find(int id)
        {
            var book = db.books.Include(a => a.Auther).SingleOrDefault(b => b.Idbook == id);
            return book;
        }

        public IList<Book> list()
        {
            return db.books.Include(a=>a.Auther).ToList(); //bring book and his auther a=>a.auther
        }

        public void update(int id, Book newbook)
        {
            //// var book = books.SingleOrDefault(b => b.Idbook == id);  repeted in find method
            //var book = find(id);
            //book.Title = newbook.Title;
            //book.Description = newbook.Description;
            //book.Auther = newbook.Auther;
            //book.imageurl = newbook.imageurl;
            db.Update(newbook);
            db.SaveChanges();
        }

        public List<Book> search(string term) 
        {
            var result = db.books.Include(a=>a.Auther).Where(b=>b.Title.Contains(term) 
            || b.Description.Contains(term)||b.Auther.Name.Contains(term)).ToList();
            return result;
        }
    }
}

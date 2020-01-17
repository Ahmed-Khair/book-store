using book_store.Models.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_store.Models
{
    public class AutherDBrepository : repositoriesInterface<Auther>
    {
        private readonly Dbcontxt db;

        public AutherDBrepository(Dbcontxt db)
        {
            this.db = db;
        }
        public void add(Auther entity)
        {
            //entity.Id_auther = Authers.Max(b => b.Id_auther) + 1;
            //Authers.Add(entity);
           db.authers.Add(entity);
            db.SaveChanges();
        }

        public void delete(int id)
        {
            var auther = find(id);
           db.authers.Remove(auther);
            db.SaveChanges();
        }

        public Auther find(int id)
        {
            var auther =db.authers.SingleOrDefault(a => a.Id_auther == id);
            return auther;
        }

        public IList<Auther> list()
        {
            return db.authers.ToList();
        }

        public List<Auther> search(string term)
        {

            return db.authers.Where(a => a.Name.Contains(term)).ToList();
        }

        public void update(int id, Auther new_auther)
        {
            //var auther = find(id);
            //auther.Name = new_auther.Name;
            db.Update(new_auther);
            db.SaveChanges();
        }
    }
}

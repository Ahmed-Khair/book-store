using book_store.Models;
using book_store.Models.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_store.repositories
{
    public class Autherrepository : repositoriesInterface<Auther>
    {
        IList<Auther> Authers;
        public Autherrepository()
        {
            Authers = new List<Auther>
            {
                new Auther
                {
                    Id_auther=1 , Name="ahmeddfg"
                },
                 new Auther
                {
                    Id_auther=2 , Name="aliiiiii"
                },
                  new Auther
                {
                    Id_auther=3 , Name="moaz"
                }
            };
        }
        public void add(Auther entity)
        {
            entity.Id_auther = Authers.Max(b => b.Id_auther) + 1;
            Authers.Add(entity);
        }

        public void delete(int id)
        {
            var auther = find(id);
            Authers.Remove(auther);
        }

        public Auther find(int id)
        {
            var auther = Authers.SingleOrDefault(a => a.Id_auther == id);
            return auther;
        }

        public IList<Auther> list()
        {
            return Authers;
        }

        public List<Auther> search(string term)
        {
            return Authers.Where(a => a.Name.Contains(term)).ToList();
        }

        public void update(int id, Auther new_auther)
        {
            var auther = find(id);
            auther.Name = new_auther.Name;
        }
    }
}

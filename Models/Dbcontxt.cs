using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_store.Models
{
    public class Dbcontxt : DbContext
    {
        public Dbcontxt(DbContextOptions<Dbcontxt> options) : base(options)
        {

        }

        public DbSet<Auther> authers { get; set; }
        public DbSet<Book> books { get; set; }
    }
}


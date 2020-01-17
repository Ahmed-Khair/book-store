using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_store.Models
{
    public class Book
    {
        [Key]
        public int Idbook { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string imageurl { get; set; }
        public Auther Auther { get; set; }
    }
}

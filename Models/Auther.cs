using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_store.Models
{
    public class Auther
    {
        [Key]
        public int Id_auther { get; set; }
        [Required]
        public string Name { get; set; }

        
    }
}

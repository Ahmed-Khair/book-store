using book_store.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_store.view_models
{
    public class book_authermodel
    {
        [Key]
       
        public int Idbook { get; set; }
       [Required]
       [MaxLength(15)]
       [MinLength(5)]
      // [StringLength(15, MinimumLength =5)]
        public string Title { get; set; }
        [Required]
        [MaxLength(120)]
        [MinLength(5)]
        public string Description { get; set; }
        public int Id_auther { get; set; }
        public List<Auther>authers { get; set; }
        public string imageurl { get; set; }/* to upload imagefile in edit view*/
        public IFormFile File { get; set; }/* to upload imagefile in create & details views*/
        
    }
}

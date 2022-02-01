using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Pandora.Models
{
    public class Movie
    {
        //prev required were Name and Genre only
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }


        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//This page provides model configuration for working with the movie application form
namespace FilmCollection.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int ApplicationID { get; set; }     
        [Required]
        public string Title { get; set; }
        [Required(ErrorMessage ="Title is Required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Year is Required")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Director is Required")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }

        //Build FK relationship
        [Required(ErrorMessage = "Category is Required")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}

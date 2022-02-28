using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie
{
    public class Customer: Person
    {
       
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(4)]
        [MinLength(2)]
        public string Gender  { get; set; }
        public string Birthday  { get; set; }
    }
}
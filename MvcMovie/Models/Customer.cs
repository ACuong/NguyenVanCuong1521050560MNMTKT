using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie
{
    public class Customer: Person
    {
       
        [Required(ErrorMessage ="Email không được để trống")]
        [StringLength(50)]
        [EmailAddress]
        
        public string Email { get; set; }

        [Required(ErrorMessage ="Thể loại không được để trống")]
        [MaxLength(20)]
        [MinLength(2)]
        public string Gender  { get; set; }


        [StringLength(20, MinimumLength =3)]  
        public string Birthday  { get; set; }
    }
}
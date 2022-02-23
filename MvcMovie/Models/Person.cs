using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie
{
    public class Person
    {
        [Key]
        [Display(Name ="Mã người")]
        public string PersonID { get; set; }

        [Required]
        [Display(Name ="Tên người")]
        public string PersonName { get; set; }
    }
}
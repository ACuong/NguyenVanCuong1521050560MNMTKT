using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie
{
    public class Person
    {
        
        [Key]
        [Display(Name ="Mã người")]
        public string PersonID { get; set; }

        
        [StringLength(60, MinimumLength =3)]
        [Required(ErrorMessage ="Tên không được để trống")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")] 
        [Display(Name ="Tên người")]
        public string PersonName { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage ="Địa chỉ không được để trống")]
        public string Address { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie
{
    public class Student
    {
        [Key]
        [Display(Name ="Mã Sinh Viên")]
        public string StudentID { get; set; }


        [Required(ErrorMessage ="Tên sinh viên không được để trống")]
        [StringLength(50,MinimumLength =3)]
        [Display(Name ="Tên Sinh Viên")]
        public string StudentName { get; set; }

        [Required(ErrorMessage ="Địa chỉ không được để trống")]
        [Display(Name ="Địa chỉ")]
        [MaxLength(50)]
        public string Address { get; set; }
    }
}
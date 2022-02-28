using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie
{
    public class Student
    {
        [Key]
        [Display(Name ="Mã Sinh Viên")]
        public string StudentID { get; set; }

        [Required]
        [Display(Name ="Tên Sinh Viên")]
        public string StudentName { get; set; }

        public string Address { get; set; }
    }
}
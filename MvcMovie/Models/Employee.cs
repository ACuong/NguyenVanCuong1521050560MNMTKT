using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie{
    public class Employee
    {
        [Key]
        [Display(Name ="Mã Nhân Viên")]
        public string EmployeeID { get; set; }

        [Required]
        [Display(Name ="Tên Nhân Viên")]
        public string EmployeeName { get; set; }
        public string Address { get; set; }
    }
}
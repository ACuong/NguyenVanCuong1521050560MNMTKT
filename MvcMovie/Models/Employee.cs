using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie{
    public class Employee
    {
        [Key]
        [Display(Name ="Mã Nhân Viên")]
        public string EmployeeID { get; set; }

        [MaxLength(30)]
        [MinLength(10)]
        [Required(ErrorMessage = "Tên nhân viên không được để trống")]
        [Display(Name ="Tên Nhân Viên")]
        public string EmployeeName { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }
    }
}
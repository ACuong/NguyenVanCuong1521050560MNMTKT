using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class EmployeeAddressViewModel
    {
        public List<Employee> Employees { get; set; }
        public SelectList Adress { get; set; }
        public string EmployeeAdress { get; set; }
        public string SearchString { get; set; }
    }
}
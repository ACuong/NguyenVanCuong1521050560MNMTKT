using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class CustomerGioiTinhViewModel
    {
        public List<Customer> Customers { get; set; }
        public SelectList Gender { get; set; }
        public string GenderIn { get; set; }
        public string SearchString { get; set; }
    }
}
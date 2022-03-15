using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class PersonAddressViewModel
    {
        public List<Person> Persons { get; set; }
        public SelectList Adress { get; set; }
        public string PersonAdress { get; set; }
        public string SearchString { get; set; }
    }
}
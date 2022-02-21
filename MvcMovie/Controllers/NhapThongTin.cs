using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class NhapThongTinController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index(string Ten, int Tuoi)
        {
            @ViewBag.Ten =Ten;
            @ViewBag.Tuoi =Tuoi;
            return View();
        }
    }
}
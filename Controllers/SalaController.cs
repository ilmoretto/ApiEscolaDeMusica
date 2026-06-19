using Microsoft.AspNetCore.Mvc;

namespace AppEscolaDeMusica.Controllers
{
    public class SalaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

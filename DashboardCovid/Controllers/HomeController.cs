using DashboardCovid.Domain.Interfaces;
using DashboardCovid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DashboardCovid.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInfeccaoPaisService infeccaoPaisService;

        public HomeController(IInfeccaoPaisService infeccaoPaisService)
        {
            this.infeccaoPaisService = infeccaoPaisService;
        }

        public IActionResult Index()
        {
            var infeccoes = infeccaoPaisService.Listar().MapearInfeccaoPaisesParaModel();
            ViewData["Infeccoes"] = infeccoes;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

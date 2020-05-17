using DashboardCovid.Domain.Interfaces;
using DashboardCovid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DashboardCovid.Controllers
{
    //Controller para tela inicial com dashboard de infecções
    public class HomeController : Controller
    {
        private readonly IInfeccaoPaisService infeccaoPaisService;

        //Construtor que recebe instâncias das classes por injeção de dependência
        public HomeController(IInfeccaoPaisService infeccaoPaisService)
        {
            this.infeccaoPaisService = infeccaoPaisService;
        }

        //Action inicial que lista as infecções e as envia para a tela
        public IActionResult Index()
        {
            var infeccoes = infeccaoPaisService.Listar().MapearInfeccaoPaisesParaModel();
            ViewData["Infeccoes"] = infeccoes;

            return View();
        }

        //Tratamento para casos de erros 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

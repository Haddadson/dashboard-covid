using DashboardCovid.Domain.Interfaces;
using DashboardCovid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DashboardCovid.Controllers
{
    //Controller para tela de login e CRUD do administrador
    public class AdminController : Controller
    {
        private const string LOGIN = "admin";
        private const string SENHA = "password";

        private readonly IPaisService paisService;
        private readonly IInfeccaoPaisService infeccaoPaisService;

        //Construtor que recebe instâncias das classes por injeção de dependência
        public AdminController(IPaisService paisService,
            IInfeccaoPaisService infeccaoPaisService)
        {
            this.paisService = paisService;
            this.infeccaoPaisService = infeccaoPaisService;
        }
        
        [HttpGet]
        //Action inicial, verifica se o Administrador está autenticado e redireciona para o login ou para a página de CRUD
        public IActionResult Index()
        {
            bool autenticado = TempData["Autenticado"] != null && (bool)TempData["Autenticado"];

            if (autenticado)
            {
                ViewData["Autenticado"] = true;
                TempData["Autenticado"] = true;
                TempData.Keep();

                //Lista os registros de infecções e os países disponíveis para cadastro
                var infeccoes = infeccaoPaisService.Listar().MapearInfeccaoPaisesParaModel();
                var paises = paisService.ListarPaises().MapearPaisesParaModel();
                ViewData["Paises"] = paises.Select(p => p.Pais).ToList();
                ViewData["Infeccoes"] = infeccoes;

                return View("ControleDashboard");
            }

            return View();
        }

        [HttpPost]
        //Action para realizar a autenticação do administrador
        public IActionResult Index(string login, string senha)
        {
            bool autenticado = (login == LOGIN && senha == SENHA) || 
                (TempData["Autenticado"] != null && (bool)TempData["Autenticado"]);

            ViewData["Autenticado"] = autenticado;
            TempData["Autenticado"] = autenticado;
            TempData.Keep();

            if (autenticado)
            {
                //Lista os registros de infecções e os países disponíveis para cadastro
                var infeccoes = infeccaoPaisService.Listar().MapearInfeccaoPaisesParaModel();
                var paises = paisService.ListarPaises().MapearPaisesParaModel();
                ViewData["Paises"] = paises.Select(p => p.Pais).ToList();
                ViewData["Infeccoes"] = infeccoes;

                return View("ControleDashboard");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        //Action para criar um novo registro ou atualizar um existente 
        public IActionResult CriarOuAtualizar(string pais, string casosConfirmados, string mortes, string recuperados)
        {
            bool sucesso;
            string msgErro = string.Empty;

            if(int.Parse(casosConfirmados) > int.Parse(mortes) + int.Parse(recuperados))
            {
                sucesso = infeccaoPaisService.CriarOuAtualizar(pais, int.Parse(casosConfirmados),
                    int.Parse(mortes), int.Parse(recuperados));
            }
            else
            {
                sucesso = false;
                msgErro = "A quantidade de mortes + recuperados excede os casos confirmados";
            }

            return RedirectToAction("ControleDashboard", new { sucesso, msgErro });
        }

        //Action para remover um registro de infecção por ID
        public IActionResult Remover(string infeccaoId)
        {
            bool sucesso = infeccaoPaisService.RemoverPorId(infeccaoId);

            return RedirectToAction("ControleDashboard", new { sucesso });
        }

        //Action para redirecionar o administrador para a tela de CRUD
        //Verifica se está autenticado e envia para a tela de login caso não esteja
        public IActionResult ControleDashboard(bool? sucesso = null, string msgErro = null)
        {
            bool autenticado = TempData["Autenticado"] != null && (bool)TempData["Autenticado"];

            if (autenticado)
            {
                ViewData["Autenticado"] = true;
                TempData["Autenticado"] = true;
                TempData.Keep();
            }
            else
            {
                return View("Index");
            }

            var infeccoes = infeccaoPaisService.Listar().MapearInfeccaoPaisesParaModel();

            var paises = paisService.ListarPaises().MapearPaisesParaModel();

            ViewData["Paises"] = paises.Select(p => p.Pais).ToList();
            ViewData["Infeccoes"] = infeccoes;

            if(sucesso != null)
                ViewData["SucessoCadastro"] = sucesso;

            if(!string.IsNullOrWhiteSpace(msgErro))
                ViewData["MsgErro"] = msgErro;

            return View("ControleDashboard");
        }

        //Action responsável por efetuar o logout, removendo a autenticação
        public IActionResult Logout()
        {
            ViewData["Autenticado"] = null;
            TempData["Autenticado"] = null;
            TempData.Keep();

            return RedirectToAction("Index");
        }
    }
}
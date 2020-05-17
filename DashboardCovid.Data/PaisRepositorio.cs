using DashboardCovid.Data.Entidades;
using DashboardCovid.Data.Interfaces;
using DashboardCovid.Shared;
using System.Collections.Generic;

namespace DashboardCovid.Data
{
    //Classe de acesso aos dados
    //Acessa API externa para obter informações sobre países
    public class PaisRepositorio : RestClientBase, IPaisRepositorio
    {
        //Construtor que recebe instâncias das classes por injeção de dependência
        //Obtém a URL do serviço presente no appsettings e envia para o RestClientBase
        public PaisRepositorio(Aplicacao aplicacao) : base(aplicacao.ServicoPaises) { }

        //Método para listar todos países disponíveis na API
        public List<PaisEntidade> ListarPaises()
        {
            Request.Resource = "/PUC/Paisesv2/0/1000";
            Request.Method = RestSharp.Method.GET;

            return Executar<List<PaisEntidade>>();
        }
    }
}

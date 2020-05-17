using DashboardCovid.Data.Entidades;
using DashboardCovid.Data.Interfaces;
using DashboardCovid.Shared;
using System.Collections.Generic;

namespace DashboardCovid.Data
{
    public class PaisRepositorio : RestClientBase, IPaisRepositorio
    {

        public PaisRepositorio(Aplicacao aplicacao) : base(aplicacao.ServicoPaises) { }

        public List<PaisEntidade> ListarPaises()
        {
            Request.Resource = "/PUC/Paisesv2/0/1000";
            Request.Method = RestSharp.Method.GET;

            return Executar<List<PaisEntidade>>();
        }
    }
}

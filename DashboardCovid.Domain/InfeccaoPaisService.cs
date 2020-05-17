using DashboardCovid.Data.Interfaces;
using DashboardCovid.Domain.DTOs;
using DashboardCovid.Domain.Interfaces;
using System.Collections.Generic;

namespace DashboardCovid.Domain
{
    public class InfeccaoPaisService : IInfeccaoPaisService
    {
        private readonly IInfeccaoPaisRepositorio infeccaoPaisRepositorio;

        public InfeccaoPaisService(IInfeccaoPaisRepositorio infeccaoPaisRepositorio)
        {
            this.infeccaoPaisRepositorio = infeccaoPaisRepositorio;
        }

        public List<InfeccaoPaisDto> Listar()
        {
            return infeccaoPaisRepositorio.Listar().MapearInfeccaoPaises();
        }

        public bool CriarOuAtualizar(string pais, int casos, int mortes, int recuperados)
        {
            if (string.IsNullOrWhiteSpace(pais))
                return false;

            return infeccaoPaisRepositorio.CriarOuAtualizar(pais, casos, mortes, recuperados);
        }

        public bool RemoverPorId(string idInfeccaoPais)
        {
            if (string.IsNullOrWhiteSpace(idInfeccaoPais))
                return false;

            return infeccaoPaisRepositorio.RemoverPorId(idInfeccaoPais);
        }
    }
}

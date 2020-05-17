using DashboardCovid.Data.Interfaces;
using DashboardCovid.Domain.DTOs;
using DashboardCovid.Domain.Interfaces;
using System.Collections.Generic;

namespace DashboardCovid.Domain
{
    //Classe com regras de negócio para tratamento de dados e acesso à camada de repositório
    public class InfeccaoPaisService : IInfeccaoPaisService
    {
        private readonly IInfeccaoPaisRepositorio infeccaoPaisRepositorio;

        //Construtor que recebe instâncias das classes por injeção de dependência
        public InfeccaoPaisService(IInfeccaoPaisRepositorio infeccaoPaisRepositorio)
        {
            this.infeccaoPaisRepositorio = infeccaoPaisRepositorio;
        }

        //Método para listar todas infecções registradas
        public List<InfeccaoPaisDto> Listar()
        {
            return infeccaoPaisRepositorio.Listar().MapearInfeccaoPaises();
        }

        //Método para criar ou atualizar infecção, retorna true em caso de sucesso e false em caso de falha
        public bool CriarOuAtualizar(string pais, int casos, int mortes, int recuperados)
        {
            if (string.IsNullOrWhiteSpace(pais))
                return false;

            return infeccaoPaisRepositorio.CriarOuAtualizar(pais, casos, mortes, recuperados);
        }

        //Método para remover infecção, retorna true em caso de sucesso e false em caso de falha
        public bool RemoverPorId(string idInfeccaoPais)
        {
            if (string.IsNullOrWhiteSpace(idInfeccaoPais))
                return false;

            return infeccaoPaisRepositorio.RemoverPorId(idInfeccaoPais);
        }
    }
}

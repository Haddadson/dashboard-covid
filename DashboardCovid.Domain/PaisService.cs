using DashboardCovid.Data.Interfaces;
using DashboardCovid.Domain.DTOs;
using DashboardCovid.Domain.Interfaces;
using System.Collections.Generic;

namespace DashboardCovid.Services
{
    //Classe com regras de negócio para tratamento de dados e acesso à camada de repositório
    public class PaisService : IPaisService
    {
        private readonly IPaisRepositorio paisRepositorio;

        //Construtor que recebe instâncias das classes por injeção de dependência
        public PaisService(IPaisRepositorio paisRepositorio)
        {
            this.paisRepositorio = paisRepositorio;
        }

        //Método para listar todos páises disponíveis para cadastro
        public List<PaisDto> ListarPaises()
        {
            return paisRepositorio.ListarPaises().MapearPaises();
        }
    }
}
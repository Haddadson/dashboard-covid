using DashboardCovid.Data.Interfaces;
using DashboardCovid.Domain.DTOs;
using DashboardCovid.Domain.Interfaces;
using System.Collections.Generic;

namespace DashboardCovid.Services
{
    public class PaisService : IPaisService
    {

        private readonly IPaisRepositorio paisRepositorio;
        
        public PaisService(IPaisRepositorio paisRepositorio)
        {
            this.paisRepositorio = paisRepositorio;
        }

        public List<PaisDto> ListarPaises()
        {
            return paisRepositorio.ListarPaises().MapearPaises();
        }
    }
}

using DashboardCovid.Domain.DTOs;
using System.Collections.Generic;

namespace DashboardCovid.Domain.Interfaces
{
    public interface IInfeccaoPaisService
    {
        List<InfeccaoPaisDto> Listar();
        bool CriarOuAtualizar(string pais, int casos, int mortes, int recuperados);
        bool RemoverPorId(string idInfeccaoPais);
    }
}

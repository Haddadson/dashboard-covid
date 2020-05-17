using DashboardCovid.Data.Entidades;
using System.Collections.Generic;

namespace DashboardCovid.Data.Interfaces
{
    public interface IInfeccaoPaisRepositorio
    {
        List<InfeccaoPaisEntidade> Listar();
        bool CriarOuAtualizar(string pais, int casos, int mortes, int recuperados);
        bool RemoverPorId(string idInfeccaoPais);
    }
}

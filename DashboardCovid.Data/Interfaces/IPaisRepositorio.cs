using DashboardCovid.Data.Entidades;
using System.Collections.Generic;

namespace DashboardCovid.Data.Interfaces
{
    public interface IPaisRepositorio
    {
        List<PaisEntidade> ListarPaises();
    }
}

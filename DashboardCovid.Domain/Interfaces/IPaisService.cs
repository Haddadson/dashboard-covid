using DashboardCovid.Domain.DTOs;
using System.Collections.Generic;

namespace DashboardCovid.Domain.Interfaces
{
    public interface IPaisService
    {
        List<PaisDto> ListarPaises();
    }
}

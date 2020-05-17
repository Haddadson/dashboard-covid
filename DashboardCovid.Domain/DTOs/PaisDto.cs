using DashboardCovid.Data.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DashboardCovid.Domain.DTOs
{
    public class PaisDto
    {
        public string CodigoArea { get; set; }
        public string Pais { get; set; }
        public string Sigla { get; set; }
    }

    public static class PaisDtoExtension
    {
        public static PaisDto MapearPais(this PaisEntidade entidade)
        {
            if (entidade == null)
                return null;

            return new PaisDto()
            {
                CodigoArea = entidade.CodigoArea,
                Pais = entidade.Pais,
                Sigla = entidade.Sigla
            };
        }

        public static List<PaisDto> MapearPaises(this IEnumerable<PaisEntidade> entidades)
        {
            if (!entidades.Any())
                return new List<PaisDto>();

            return entidades.Select(MapearPais).ToList();
        }
    }
}

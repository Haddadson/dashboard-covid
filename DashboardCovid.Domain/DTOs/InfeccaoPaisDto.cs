using DashboardCovid.Data.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DashboardCovid.Domain.DTOs
{
    public class InfeccaoPaisDto
    {
        public int InfeccaoPaisId { get; set; }
        public string Pais { get; set; }
        public int CasosConfirmados { get; set; }
        public int Mortes { get; set; }
        public int Recuperados { get; set; }
    }

    public static class InfeccaoPaisDtoExtension
    {
        public static InfeccaoPaisDto MapearInfeccaoPais(this InfeccaoPaisEntidade entidade)
        {
            if (entidade == null)
                return null;

            return new InfeccaoPaisDto()
            {
                CasosConfirmados = entidade.CasosConfirmados,
                Pais = entidade.Pais,
                InfeccaoPaisId = entidade.InfeccaoPaisId,
                Mortes = entidade.Mortes,
                Recuperados = entidade.Recuperados
            };
        }

        public static List<InfeccaoPaisDto> MapearInfeccaoPaises(this IEnumerable<InfeccaoPaisEntidade> entidades)
        {
            if (!entidades.Any())
                return new List<InfeccaoPaisDto>();

            return entidades.Select(MapearInfeccaoPais).ToList();
        }
    }
}

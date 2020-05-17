using DashboardCovid.Domain.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DashboardCovid.Models
{
    public class InfeccaoPaisModel
    {
        public int InfeccaoPaisId { get; set; }
        public string Pais { get; set; }
        public int CasosConfirmados { get; set; }
        public int Mortes { get; set; }
        public int Recuperados { get; set; }
    }

    public static class InfeccaoPaisModelExtension
    {
        public static InfeccaoPaisModel MapearInfeccaoPaisParaModel(this InfeccaoPaisDto dto)
        {
            if (dto == null)
                return null;

            return new InfeccaoPaisModel()
            {
                CasosConfirmados = dto.CasosConfirmados,
                Pais = dto.Pais,
                InfeccaoPaisId = dto.InfeccaoPaisId,
                Mortes = dto.Mortes,
                Recuperados = dto.Recuperados
            };
        }

        public static List<InfeccaoPaisModel> MapearInfeccaoPaisesParaModel(this IEnumerable<InfeccaoPaisDto> dtos)
        {
            if (!dtos.Any())
                return new List<InfeccaoPaisModel>();

            return dtos.Select(MapearInfeccaoPaisParaModel).ToList();
        }
    }
}

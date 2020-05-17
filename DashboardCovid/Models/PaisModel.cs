using DashboardCovid.Domain.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DashboardCovid.Models
{
    public class PaisModel
    {
        public string CodigoArea { get; set; }
        public string Pais { get; set; }
        public string Sigla { get; set; }
    }


    public static class PaisModelExtension
    {
        public static PaisModel MapearPaisParaModel(this PaisDto dto)
        {
            if (dto == null)
                return null;

            return new PaisModel()
            {
                CodigoArea = dto.CodigoArea,
                Pais = dto.Pais,
                Sigla = dto.Sigla
            };
        }

        public static List<PaisModel> MapearPaisesParaModel(this List<PaisDto> dtos)
        {
            if (!dtos.Any())
                return new List<PaisModel>();

            return dtos.Select(MapearPaisParaModel).ToList();
        }
    }
}

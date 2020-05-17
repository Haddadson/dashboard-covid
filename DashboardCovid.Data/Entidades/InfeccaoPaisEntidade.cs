using System.ComponentModel.DataAnnotations;

namespace DashboardCovid.Data.Entidades
{
    public class InfeccaoPaisEntidade
    {
        [Key]
        public int InfeccaoPaisId { get; set; }
        public string Pais { get; set; }
        public int CasosConfirmados { get; set; }
        public int Mortes { get; set; }
        public int Recuperados { get; set; }
    }
}

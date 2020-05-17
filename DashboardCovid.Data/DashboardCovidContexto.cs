using DashboardCovid.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DashboardCovid.Data
{
    public class DashboardCovidContexto : DbContext
    {

        //Construtor para configuração do contexto por injeção de dependência
        public DashboardCovidContexto(DbContextOptions<DashboardCovidContexto> options) : base(options) { }

        //Entidade que representa a tabela no banco de dados
        public DbSet<InfeccaoPaisEntidade> Infeccoes { get; set; }

    }
}

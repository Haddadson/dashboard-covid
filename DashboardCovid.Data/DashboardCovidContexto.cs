using DashboardCovid.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DashboardCovid.Data
{
    public class DashboardCovidContexto : DbContext
    {

        public DashboardCovidContexto(DbContextOptions<DashboardCovidContexto> options) : base(options) { }

        public DbSet<InfeccaoPaisEntidade> Infeccoes { get; set; }

    }
}

using DashboardCovid.Data.Entidades;
using DashboardCovid.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DashboardCovid.Data
{
    public class InfeccaoPaisRepositorio : IInfeccaoPaisRepositorio
    {
        private readonly DashboardCovidContexto dashboardCovidContexto;

        public InfeccaoPaisRepositorio(DashboardCovidContexto contexto)
        {
            this.dashboardCovidContexto = contexto;
        }

        public bool CriarOuAtualizar(string pais, int casos, int mortes, int recuperados)
        {
            try
            {
                // Se existir infecção para o país, atualiza os dados
                if (dashboardCovidContexto.Infeccoes.Where(infeccao => infeccao.Pais == pais).Any())
                {
                    var inf = dashboardCovidContexto.Infeccoes.Where(infeccao => infeccao.Pais == pais).First();
                    inf.CasosConfirmados = casos;
                    inf.Mortes = mortes;
                    inf.Recuperados = recuperados;
                    dashboardCovidContexto.Update(inf);
                }
                //Senão, registra uma nova infecção
                else
                {
                    var novaInfeccaoPais = new InfeccaoPaisEntidade
                    {
                        Pais = pais,
                        CasosConfirmados = casos,
                        Mortes = mortes,
                        Recuperados = recuperados
                    };

                    dashboardCovidContexto.Infeccoes.Add(novaInfeccaoPais);
                }
                dashboardCovidContexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public List<InfeccaoPaisEntidade> Listar()
        {
            return dashboardCovidContexto.Infeccoes.ToList();
        }

        public bool RemoverPorId(string idInfeccaoPais)
        {
            try
            {

                //Busca o registro da infeccção por Id e retorna o primeiro
                //Retorna false se não encontrar
                var itemASerRemovido = dashboardCovidContexto.Infeccoes.Where(i => i.InfeccaoPaisId == 
                    int.Parse(idInfeccaoPais)).FirstOrDefault();

                if (itemASerRemovido == null)
                    return false;

                dashboardCovidContexto.Infeccoes.Remove(itemASerRemovido);
                dashboardCovidContexto.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}

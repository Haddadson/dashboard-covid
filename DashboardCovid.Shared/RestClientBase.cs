using RestSharp;
using System;
using System.Net;

namespace DashboardCovid.Shared
{
    //Estrutura para facilitar o uso de requisições Http à APIs externas
    public class RestClientBase : RestClient
    {
        protected RestRequest Request;

        protected RestClientBase(string url) : base(url)
        {
            IniciarRequest();
        }

        private void IniciarRequest()
        {
            Request = new RestRequest
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = Serializador.Instancia
            };

            AddHandler("application/json", () => { return Serializador.Instancia; });
        }

        protected void DefinirHeaderTipoConteudo(string valor)
        {
            DefinirHeader("Content-Type", valor);
            DefinirTipoConteudo(valor);
        }

        protected void DefinirAutorizacao(string chave)
        {
            DefinirHeader("Authorization", $"Basic {chave}");
        }

        protected void DefinirHeader(string chave, string valor)
        {
            Request.AddHeader(chave, valor);
        }

        protected void DefinirTipoConteudo(string valor)
        {
            Request.JsonSerializer.ContentType = valor;
        }

        protected void DefinirTimeout(int miliseconds)
        {
            Request.Timeout = miliseconds;
        }

        protected void AdicionarBodyRequisicao(object body)
        {
            Request.AddJsonBody(body);
        }

        protected void AdicionarParametro(string nome, object valor)
        {
            Request.AddParameter(nome, valor);
        }

        private string ObterMensagemExcecao(IRestResponse response)
        {
            return String.IsNullOrEmpty(response.Content) ? response.ErrorMessage : response.Content;
        }

        protected T Executar<T>() where T : new()
        {
            var resultado = Execute<T>(Request);

            ValidarRetorno(resultado);

            IniciarRequest();

            return resultado.Data;
        }

        protected IRestResponse Executar()
        {
            var resultado = Execute(Request);

            ValidarRetorno(resultado);

            IniciarRequest();

            return resultado;
        }

        private void ValidarRetorno(IRestResponse resultado)
        {
            if (resultado.StatusCode != HttpStatusCode.OK &&
                resultado.StatusCode != HttpStatusCode.Unauthorized &&
                resultado.StatusCode != HttpStatusCode.Created)
                throw new HttpException(resultado.StatusCode, ObterMensagemExcecao(resultado));
        }
    }
}

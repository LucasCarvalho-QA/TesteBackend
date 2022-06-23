using TestBackend.Setup;
using TestBackend.Utils.ReportManagement;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace TestBackend.Utils.Validador
{
    public static class ValidadorCenarioAlternativo
    {
        public static Report reportService = new Report();

        public enum Validacao
        {
            Obrigatorio_Vazio,
            Obrigatorio_Invalido,
            Obrigatorio_Caracteres_Excedido,
            Obrigatorio_Caracteres_Minimos_Nao_Atingidos,
            Data_Idade_Minima_Nao_Atingida,
            Data_Valor_Informado_Incorretamente,
            ObjetoNaoEncontrado,
            Enum_Obrigatorio_Invalido,
            Enum_Obrigatorio_Vazio,
            Sucesso,
            Obrigatorio_Inexistente,
            Consulta,
            ConsultaSemRetorno,
            Obrigatorio_Duplicado,
            PessoaJuridica,
            Cliente_Empresa_nao_relacionado,
            Cliente_EntePublico,
            Ja_Realizado,
            Nao_Autorizado,
            Nao_Estornavel,
            ErroProcesso,
            ObjetoJaRelacionado,
            ObjetoNaoRelacionado
        }
               

        public static void ValidarCenarioAlternativo(HttpStatusCode httpCodeEsperado, Validacao validacao, object contrato = null)
        {
           
        }

        public static void ValidarRetornoVazio(HttpStatusCode httpCodeEsperado, IRestResponse response)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(httpCodeEsperado, response.StatusCode);
                Assert.AreEqual("{}", response.Content, "Consulta com resultado");
            });

            reportService.GenerateReport(response);
        }

        public static void ValidarRetorno_ListaNaoVazia(HttpStatusCode httpCodeEsperado, IRestResponse response, string mensagem)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(httpCodeEsperado, response.StatusCode);
                Assert.AreNotEqual("[]", response.Content, mensagem);
            });

            reportService.GenerateReport(response);
        }

        
    }
}

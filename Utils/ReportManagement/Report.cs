using TestBackend.Setup;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBackend.Utils.ReportManagement
{
    public class Report : ReportService
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public string Headers { get; set; }
        public string CurrentRequestElapsedTime { get; set; }
        public string ElapsedTime { get; set; }
        public string TestMethodName { get; set; }
        public string AzureTestCaseName { get; set; }
        public string BodyRequest { get; set; }
        public string BodyResponse { get; set; }
        public string HttpStatusResponse { get; set; }
        public string Datetime { get; set; }
        public string Outcome { get; set; }
        public string ExpectedOutcome { get; set; }
        public string TestCategory { get; set; }
        public string StackTrace { get; set; }
        public string ExpectedBodyRequest { get; set; }

        public static Report report = null;

        public static PartialReport partialReport = new PartialReport();


        public static List<string> responseMensagensValidadas = new List<string>();

        public void GenerateReport(IRestResponse response)
        {
            Report reportBody = new Report
            {
                Url = response.ResponseUri.AbsoluteUri,
                Method = response.Request.Method.ToString(),
                Datetime = DateTime.Now.ToString(),
                Outcome = string.Empty,
                CurrentRequestElapsedTime = Runner.tempoDecorridoRequisicao,
                ElapsedTime = SetupTest.tempoDecorridoTotal,
#pragma warning disable CS0612 // Type or member is obsolete
                Headers = StringFormatter.HeaderFormatter(response.Request.Parameters.ToList().Where(x => x.Type.ToString() == "HttpHeader")),
#pragma warning restore CS0612 // Type or member is obsolete
                BodyResponse = StringFormatter.JsonIndent(response.Content),
                HttpStatusResponse = response.StatusCode.ToString(),
                TestMethodName = TestContext.CurrentContext.Test.MethodName,
                AzureTestCaseName = TestContext.CurrentContext.Test.Name,
                ExpectedBodyRequest = StringFormatter.ListToString(responseMensagensValidadas)
            };

            if (response.Request.Body == null)
                reportBody.BodyRequest = string.Empty;
            else
                reportBody.BodyRequest = StringFormatter.JsonIndent(response.Request.Body.Value.ToString());

            report = reportBody;
        }

        public string GetReport(Report report)
        {
            return $"================================================================================================== \n" +
                    $"URL: {report.Url} \n" +
                    $"MÉTODO: {report.Method} \n" +
                    $"DATA: {report.Datetime} \n" +
                    $"NOME DO MÉTODO: {report.TestMethodName} \n" +
                    $"AZURE TEST CASE: {report.AzureTestCaseName} \n" +
                    $"RESULTADO: {report.Outcome} \n" +
                    $"DURAÇÃO DA CHAMADA: {report.CurrentRequestElapsedTime} segundos\n\n" +
                    $"TEMPO TOTAL DE EXECUÇÃO: {report.ElapsedTime} segundos\n" +
                    $"================================================================================================== \n" +
                    $"                           HEADERS    \n" +
                    $"================================================================================================== \n" +
                    $"{report.Headers} \n" +
                    $"================================================================================================== \n" +
                    $"                           REQUEST    \n" +
                    $"================================================================================================== \n" +
                    $"{report.BodyRequest} \n" +
                    $"================================================================================================== \n" +
                    $"                           RESPONSE   \n" +
                    $"================================================================================================== \n" +
                    $"{report.BodyResponse} \n" +
                    $"{report.ExpectedBodyRequest} \n" +
                    $"================================================================================================== \n" +
                    $"                     HTTP STATUS RESPONSE \n" +
                    $"================================================================================================== \n" +
                    $"Esperado: {report.ExpectedOutcome} \n" +
                    $"Recebido: {report.HttpStatusResponse} \n" +
                    $"================================================================================================== \n" +
                    $"              CURL (Importar request no Postman) \n" +
                    $"  Instruções" +
                    $"  \n1) Copie todo o CURL" +
                    $"  \n2) Postman > Import > Raw Text " +
                    $"  \n3) Cole e prossiga\n" +
                    $"================================================================================================== \n" +
                    $"↓↓↓↓↓ Início ↓↓↓↓↓ \n\n" +
                    $"{GenerateCurl(report.Headers, report.BodyRequest, report.Url)} \n\n" +
                    $"↑↑↑↑↑ Fim ↑↑↑↑↑ \n" +
                    $"================================================================================================== \n" +
                    $"                          STACK TRACE \n" +
                    $"================================================================================================== \n" +
                    $"{report.StackTrace} \n" +
                    $"================================================================================================== \n" +
                    $"                      HISTÓRICO DA TRANSAÇÃO \n" +
                    $"{partialReport.GetPartialReport()}" +
                    $"================================================================================================== \n";
        }
    }
}

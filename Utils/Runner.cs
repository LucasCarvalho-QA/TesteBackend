using TestBackend.Setup;
using TestBackend.Utils.ReportManagement;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestBackend.Utils
{
    public class Runner : SetupTest
    {
        public static string bearerToken = null;
        internal static Report report = new Report();
        internal static PartialReport partialReport = new PartialReport();
        public static string tempoDecorridoRequisicao = string.Empty;

        public IRestResponse ExecuteRestCall(Method method, int? id, object bodyRequest = null, Dictionary<string, string> customHeader = null, bool partialReportFlag = false)
        {
            LimparVariaveis();

            string token = "4c97e60b3df0585dec6c0c67b40167544635f7e6e796ddadea302f2ff3ea2c44";

            RestClient client = new RestClient("https://gorest.co.in/public/v2/users")
            {
                Authenticator = new JwtAuthenticator(token)
            };

            RestRequest request = new RestRequest($"https://gorest.co.in/public/v2/users/{id}", method);

            if (bodyRequest != null)
                request.AddJsonBody(bodyRequest);

            var stopwatch = Stopwatch.StartNew();

            var response = client.Execute(request);

            stopwatch.Stop();

            ConsolidarExecucao(request, response, partialReportFlag, stopwatch);
            return response;
        }


        public static void ConsolidarExecucao(RestRequest request, IRestResponse response, bool partialReportFlag = false, Stopwatch stopwatch = null)
        {
            actualResult = response.StatusCode.ToString();
            globalResponse = response;
            tempoDecorridoRequisicao = stopwatch.Elapsed.TotalSeconds.ToString("N2");

            if (request.Body != null)
                globalRequest = request.Body.Value.ToString();

            if (partialReportFlag)
                partialReport.GeneratePartialReport(response);
            else
                report.GenerateReport(response);
        }

        public static string SetTimestamp()
        {
            return ReportService.timestamp = DateTime.Now.Ticks.ToString();
        }

        public static Dictionary<string, string> GetDefaultHeader()
        {
            return new Dictionary<string, string>()
            {
                {"Content-Type","application/json;charset=UTF-8"}
            };
        }


    }
}

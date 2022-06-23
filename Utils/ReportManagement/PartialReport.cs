using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBackend.Utils.ReportManagement
{
    public class PartialReport : ReportService
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public string ElapsedTime { get; set; }
        public string Datetime { get; set; }
        public string HttpStatusResponse { get; set; }
        public string Outcome { get; set; }
        public string BodyResponse { get; set; }
        public string StackTrace { get; set; }
        public string Headers { get; set; }
        public string BodyRequest { get; set; }


        public static List<PartialReport> partialReportList = new List<PartialReport>();        
        public void GeneratePartialReport(IRestResponse response)
        {
            PartialReport reportBody = new PartialReport
            {
                Url = response.ResponseUri.AbsoluteUri,
                Method = response.Request.Method.ToString(),
                Datetime = DateTime.Now.ToString(),
                ElapsedTime = Runner.tempoDecorridoRequisicao,
                Outcome = string.Empty,
#pragma warning disable CS0612 // Type or member is obsolete
                Headers = StringFormatter.HeaderFormatter(response.Request.Parameters.ToList().Where(x => x.Type.ToString() == "HttpHeader")),
#pragma warning restore CS0612 // Type or member is obsolete
                BodyResponse = StringFormatter.JsonIndent(response.Content),
                HttpStatusResponse = response.StatusCode.ToString()
            };

            if (response.Request.Body == null)
                reportBody.BodyRequest = string.Empty;
            else
                reportBody.BodyRequest = StringFormatter.JsonPrettify(response.Request.Body.Value.ToString());

            partialReportList.Add(reportBody);
        }

        public string GetPartialReportTitle()
        {
            return $"================================================================================================== \n" +
                    $"                      HISTÓRICO DA TRANSAÇÃO \n";
        }

        public static int iterador = 0;
        public string GetPartialReport()
        {
            StringBuilder reportGenerated = new StringBuilder();
            foreach (var item in partialReportList)
            {
                iterador++;
                reportGenerated.Append(

                    $"================================================================================================== \n" +
                    $"|---------------------------------------------------------------------------| \n" +
                    $"|Passo {iterador})-------------------------------------------------------------------| \n\n" +
                    $"|DURAÇÃO DA CHAMADA: {item.ElapsedTime} segundos\n" +
                    $"|---------------------------------------------------------------------------| \n\n" +
                    $"REQUEST \n\n" +
                    $"{GenerateCurl(item.Headers, item.BodyRequest, item.Url)} \n\n" +
                    $"|---------------------------------------------------------------------------| \n\n" +
                    $"RESPONSE\n\n{item.BodyResponse} \n\n\n");
            }
            return reportGenerated.ToString();
        }
    }
}

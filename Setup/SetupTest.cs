using TestBackend.Utils.ReportManagement;
using TestBackend.Utils.Validador;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestBackend.Setup
{
    public class SetupTest : SetupClass
    {
        Report reportService = new Report();
        public static string tempoDecorridoTotal = string.Empty;
        static Stopwatch stopwatch = new Stopwatch();

        [TearDown]
        public void SetupAfterEachTest()
        {
            var localReport = Report.report;

            if (TestContext.CurrentContext.Result.FailCount > 0)
                localReport.StackTrace += TestContext.CurrentContext.Result.Message ?? "";

            localReport.Outcome = TestContext.CurrentContext.Result.Outcome.ToString();
            localReport.ExpectedOutcome = expectedResult;

            stopwatch.Stop();
            tempoDecorridoTotal = stopwatch.Elapsed.TotalSeconds.ToString("N2");
            localReport.ElapsedTime = tempoDecorridoTotal;
            reportService.SaveReport(reportService.GetReport(localReport), localReport.Outcome);
            reportService.GenerateRunSummary(localReport.Outcome);
        }

        [SetUp]
        public void SetupBeforeEachTest()
        {
            LimparVariaveis();
        }

        public static void LimparVariaveis()
        {
            tempoDecorridoTotal = string.Empty;
            stopwatch = Stopwatch.StartNew();
            Report.report = null;
            Report.responseMensagensValidadas = new List<string>();
            ReportService.timestamp = string.Empty;
            PartialReport.iterador = 0;
            PartialReport.partialReportList = new List<PartialReport>();
            globalResponse = null;
            globalRequest = null;
            campoContrato = "" ?? "";
            GerenciadorObjetos.mensagemErroList = new List<string>();
        }
    }
}

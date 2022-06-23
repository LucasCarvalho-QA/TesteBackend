using TestBackend.Setup;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestBackend.Utils.ReportManagement
{
    public class ReportService
    {
        private DirectoryInfo TestResultFolder;        
        private DirectoryInfo DatetimeFolder;
        public static string timestamp = DateTime.Now.Ticks.ToString();
        private readonly string CurrentTestFolder = TestContext.CurrentContext.TestDirectory;
        public static List<string> runSummary = new List<string>();

        public void SaveReport(string report, string outcome)
        {
            var path = GetPath();
            var name = TestContext.CurrentContext.Test.Name.Replace("á", "a").Replace("ã", "a").Replace("ó", "o").Replace("ç", "c");

            name = Regex.Replace(name, "[^0-9A-Za-z]", "");            
            var filename = $"{outcome.Replace("Failed:Error", "Failed")}_{name}.txt";

            SaveFile(report, path, filename);
        }

        public void GenerateRunSummary(string outcome)
        {            
            string line = $"{outcome} | {TestContext.CurrentContext.Test.Name}";
            SaveFile(line, GetPath().Parent, $"RunSummary_{outcome}-{SetupClass.localRunId}.txt", FileMode.Append);
        }

        private DirectoryInfo GetPath()
        {
            TestResultFolder = Directory.CreateDirectory(@"..\..\..\Runs");
            var currentClassName = TestContext.CurrentContext.Test.ClassName;

            DatetimeFolder = Directory.CreateDirectory
                (Path.Combine(TestResultFolder.FullName, DateTime.Now.Date.ToString("dd-MM-yyyy")));

            return Directory.CreateDirectory(Path.Combine(DatetimeFolder.FullName, SetupClass.localRunId, currentClassName.Split(new[] { '.' }).Last()));
        }

        public void SaveFile(string text, DirectoryInfo path, string filename, FileMode fileMode = FileMode.Create)
        {
            FileStream fs = new FileStream(Path.Combine(path.FullName, filename), fileMode, FileAccess.Write);
            using var sw = new StreamWriter(fs);
            sw.WriteLine(text);
            TestContext.AddTestAttachment(Path.Combine(path.FullName, filename));
        }

        public string GenerateCurl(string headers, string bodyRequest, string endpoint)
        {
            timestamp = DateTime.Now.Ticks.ToString();
            string customHeader = $"-H \"{headers.Replace(timestamp, "{{timestamp}}")}\"";
            string customEndpoint = $"-XPOST \"{endpoint}\"";
            string customBody = $"-d {Regex.Replace(bodyRequest, @"\s(?=([^""]*""[^""]*"")*[^""]*$)", string.Empty)}";
            return $"curl -i \n{customHeader} \n{customEndpoint} \n{customBody}";
        }
    }
}

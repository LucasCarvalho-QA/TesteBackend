using TestBackend.Utils;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackend.Setup
{
    [SetUpFixture]
    public class SetupClass
    {
        public static string localRunId = string.Empty;
        public static string expectedResult = string.Empty;
        public static string campoContrato = string.Empty;
        internal static string actualResult;
        public static IRestResponse globalResponse = null;
        public static string globalRequest = null;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            if (localRunId == string.Empty)
                localRunId = $"Local_Run_{DateTime.Now:HHmmss}";
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}

using RestSharp;
using System.Net;
using NUnit.Framework;
using Newtonsoft.Json;
using System;
using TestBackend.Setup;
using TestBackend.Utils.ReportManagement;

namespace TestBackend.Utils.Validador
{
    public class ValidadorCenarioPrincipal
    {
        public enum Cenario
        {
            Authentication,
            TreasuryAccount
        }

        public static void ValidarCenarioPrincipal(Cenario cenario, object objetoEsperado, HttpStatusCode httpCodeEsperado = HttpStatusCode.OK, IRestResponse response = null, bool lista = false)
        {
            
        }

    }
}

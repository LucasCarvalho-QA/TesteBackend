using TestBackend.Setup;
using TestBackend.Utils.ReportManagement;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using static TestBackend.Utils.Validador.ValidadorCenarioPrincipal;

namespace TestBackend.Utils.Validador
{
    public static class ValidadorEnumerados
    {
        public enum CenarioEnum
        {
            PessoaFisica_DataFormatoIncorreto,
            PessoaFisica_Genero,
            PessoaFisica_TipoManutencao,
            PessoaFisica_EstadoCivil,
            PessoaFisica_DeclaracaoPPE,
            PessoaFisica_PessoaComDeficiencia,
            PessoaFisica_Emancipado,
            PessoaFisica_DeclaracaoFacta
        }

        public static Report reportService = new Report();

     
        

        internal static string RetornarMensagem(CenarioEnum cenario, object localRequest)
        {
            switch (cenario)
            {
                #region Codigo CNAE

                //case CenarioEnum.CodigoCNAE_TipoManutencao:
                //    CodigoCnaeRequest codigoCNAE_TipoManutencao = localRequest as CodigoCnaeRequest;
                //    return $"O valor [{codigoCNAE_TipoManutencao.tipoManutencao}] não é válido. Valores permitidos [ALTERAR,EXCLUIR,INCLUIR]";

                #endregion

                default:
                    return "Mensagem não encontrada no Validador Enumerados";
            }
        }
    }
}

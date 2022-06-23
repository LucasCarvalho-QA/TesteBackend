using TestBackend.Setup;
using TestBackend.Utils.ReportManagement;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static TestBackend.Utils.Validador.ValidadorCenarioPrincipal;

namespace TestBackend.Utils.Validador
{
    public static class GerenciadorObjetos
    {
        
        public static List<string> mensagemErroList = new List<string>();

        private static bool resultado = true;
        public static Tuple<bool, object> Comparar(this object objetoA, object objetoB)
        {
            if (ReferenceEquals(objetoA, objetoB))
                return new Tuple<bool, object>(true, "");

            if ((objetoA == null) || (objetoB == null))
                return new Tuple<bool, object>(false, "");

            //Comparador de classe
            if (objetoA.GetType() != objetoB.GetType())
                return new Tuple<bool, object>(false, "");

            if (objetoA is IList && objetoB is IList)
                new Tuple<bool, object>(false, "Utilize o comparador de listas");

            //Comparando as propriedades
            ComparadorPropriedades(objetoA, objetoB);

            return new Tuple<bool, object>(resultado, mensagemErroList);
        }

        internal static object RetornarObjetosConvertidos(Cenario cenario)
        {
            throw new NotImplementedException();
        }

        private static void GerarMensagensRelatorio(string propriedade, object valorEsperado, object valorRecebido)
        {
            mensagemErroList.Add($"No campo <{propriedade}> esperava-se [{valorEsperado}] e foi encontrado [{valorRecebido}] \n");
            Report.responseMensagensValidadas.Add($"\n\nEsperado: [{valorEsperado}]\nRecebido: [{valorRecebido}]");
        }

        public static void GerenciadorComparadorListas(this List<object> objetoA, List<object> objetoB)
        {
            for (int i = 0; i <= objetoA.GetType().GetProperties().Count(); i++)
            {
                ComparadorPropriedades(objetoA[i], objetoA[i]);
            }
        }

        public static void ComparadorPropriedades(this object objetoA, object objetoB)
        {
            foreach (var property in objetoA.GetType().GetProperties())
            {
                var valorPropriedade_ObjetoA = property.GetValue(objetoA) ?? "";
                var valorPropriedade_ObjetoB = property.GetValue(objetoB) ?? "";

                if (valorPropriedade_ObjetoA.GetType().Name.Equals("DateTime"))
                {
                    valorPropriedade_ObjetoA = Convert.ToDateTime(valorPropriedade_ObjetoA).ToShortDateString();
                    valorPropriedade_ObjetoB = Convert.ToDateTime(valorPropriedade_ObjetoB).ToShortDateString();
                }

                if (!valorPropriedade_ObjetoA.Equals(valorPropriedade_ObjetoB))
                {
                    resultado = false;
                    GerarMensagensRelatorio(property.Name, valorPropriedade_ObjetoA, valorPropriedade_ObjetoB);
                }
            }
        }


    }
}

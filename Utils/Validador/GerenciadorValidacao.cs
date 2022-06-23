using TestBackend.Utils.ReportManagement;
using System;

namespace TestBackend.Utils.Validador
{
    public static class GerenciadorValidacao
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
            Falha_NaExecucao
        }

        public static Tuple<bool, string> ComparandoDoisObjetos(this object objetoA, object objetoB)
        {
            string mensagemErro = string.Empty;

            if (ReferenceEquals(objetoA, objetoB))
                return new Tuple<bool, string>(true, "");

            if ((objetoA == null) || (objetoB == null))
                return new Tuple<bool, string>(false, "");

            //Comparador de classe
            if (objetoA.GetType() != objetoB.GetType())
                return new Tuple<bool, string>(false, "");

            var resultado = true;

            //Comparando as propriedades
            foreach (var property in objetoA.GetType().GetProperties())
            {
                var valorPropriedade_ObjetoA = property.GetValue(objetoA);
                var valorPropriedade_ObjetoB = property.GetValue(objetoB);

                if (valorPropriedade_ObjetoA != null && valorPropriedade_ObjetoB != null)
                {
                    //ToDo: Melhor condição de entrada
                    if (valorPropriedade_ObjetoA.GetType().GetProperties().Length > 2)
                    {
                        //Validando cenários de maneira recursiva
                        //Identificar cenários que possam cair nessa situação
                        //ToDo: Melhorar condição de entrada
                        if (valorPropriedade_ObjetoA.GetType().Name.ToString() != "DateTime")
                            ComparandoDoisObjetos(valorPropriedade_ObjetoA, valorPropriedade_ObjetoB);

                        //Validação dentro dos subníveis do objeto (nós internos)
                        foreach (var item in valorPropriedade_ObjetoA.GetType().GetProperties())
                        {
                            var subValorPropriedadeA = item.GetValue(valorPropriedade_ObjetoA) ?? "";
                            var subValorPropriedadeB = item.GetValue(valorPropriedade_ObjetoB) ?? "";

                            if (!subValorPropriedadeA.Equals(subValorPropriedadeB))
                            {
                                resultado = false;
                                mensagemErro = $"No campo <{property.Name}.{item.Name}> esperava-se '{subValorPropriedadeA}' e foi encontrado '{subValorPropriedadeB}'";
                                Report.responseMensagensValidadas.Add($"\n\nEsperado: {subValorPropriedadeA}\nRecebido: {subValorPropriedadeB}");
                                return new Tuple<bool, string>(resultado, mensagemErro);
                            }
                        }
                    }
                    else if (!valorPropriedade_ObjetoA.Equals(valorPropriedade_ObjetoB))
                    {
                        resultado = false;
                        mensagemErro = $"No campo <{property.Name}> esperava-se {valorPropriedade_ObjetoA} e foi encontrado {valorPropriedade_ObjetoB}";
                        Report.responseMensagensValidadas.Add($"\n\nEsperado: {valorPropriedade_ObjetoA}\nRecebido: {valorPropriedade_ObjetoB}");
                        return new Tuple<bool, string>(resultado, mensagemErro);
                    }
                }
            }
            return new Tuple<bool, string>(resultado, mensagemErro);
        }
    }
}

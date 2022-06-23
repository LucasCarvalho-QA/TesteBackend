using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackend.Utils.Faker
{
    public static class GeradorEmpresa
    {
        public static string GerarNomeFantasia()
        {
            Random rdn = new Random();

            List<string> nomeEmpresa = new List<string>
            {
                "CHOAM", "Acme Corp.", "Sirius Cybernetics Corp.", "MomCorp", "Indústrias Rico","Soylent Corp.", "Very Big Corp. of America","Warbucks Industries", "Tyrell Corp.", "Empresas Wayne", "Virtucon", "Caroline","Globex", "Corporações Umbrella","Indústrias Wonka", "Indústrias Stark", "Clampett Oil", "Oceanic Airlines", "Yoyodyne Propulsion Sys", "Cyberdyne Systems Corp.","d’Anconia Copper", "Gringotes", "Oscorp", "Nakatomi Trading Corp.","Spacely Space Sprockets"
            };

            return $"{nomeEmpresa[rdn.Next(nomeEmpresa.Count)]}";
        }

        public static string GerarRazaoSocial(string chave)
        {
            Random rdn = new Random();

            List<string> nomeEmpresa = new List<string>
            {
                "CHOAM", "Acme Corp.", "Sirius Cybernetics Corp.", "MomCorp", "Indústrias Rico","Soylent Corp.", "Very Big Corp. of America","Warbucks Industries", "Tyrell Corp.", "Empresas Wayne", "Virtucon", "Caroline","Globex", "Corporações Umbrella","Indústrias Wonka", "Indústrias Stark", "Clampett Oil", "Oceanic Airlines", "Yoyodyne Propulsion Sys", "Cyberdyne Systems Corp.","d’Anconia Copper", "Gringotes", "Oscorp", "Nakatomi Trading Corp.","Spacely Space Sprockets"
            };

            return $"{nomeEmpresa[rdn.Next(nomeEmpresa.Count)]} - {chave} - Tecnologia da Informação LTDA";
        }

        private static List<int> empresasGeradas = new List<int>();

        public static int ValidaNumeroEmpresa(int empresa)
        {
            foreach (var item in empresasGeradas)
                if (item.Equals(empresa))
                    GerarNumeroEmpresa();

            empresasGeradas.Add(empresa);
            return empresa;
        }

        public static int GerarNumeroEmpresa()
        {
            Random rdn = new Random();
            return ValidaNumeroEmpresa(rdn.Next(6000, 9000));
        }

        public static string GerarCNPJ()
        {
            Random rnd = new Random();
            int n1 = rnd.Next(0, 10);
            int n2 = rnd.Next(0, 10);
            int n3 = rnd.Next(0, 10);
            int n4 = rnd.Next(0, 10);
            int n5 = rnd.Next(0, 10);
            int n6 = rnd.Next(0, 10);
            int n7 = rnd.Next(0, 10);
            int n8 = rnd.Next(0, 10);
            int n9 = 0;
            int n10 = 0;
            int n11 = 0;
            int n12 = 1;

            int Soma1 = n1 * 5 + n2 * 4 + n3 * 3 + n4 * 2 + n5 * 9 + n6 * 8 + n7 * 7 + n8 * 6 + n9 * 5 + n10 * 4 + n11 * 3 + n12 * 2;
            int DV1 = Soma1 % 11;

            if (DV1 < 2)
                DV1 = 0;
            else
                DV1 = 11 - DV1;

            int Soma2 = n1 * 6 + n2 * 5 + n3 * 4 + n4 * 3 + n5 * 2 + n6 * 9 + n7 * 8 + n8 * 7 + n9 * 6 + n10 * 5 + n11 * 4 + n12 * 3 + DV1 * 2;
            int DV2 = Soma2 % 11;

            if (DV2 < 2)
                DV2 = 0;
            else
                DV2 = 11 - DV2;

            return n1.ToString() + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10 + n11 + n12 + DV1 + DV2;
        }
    }
}

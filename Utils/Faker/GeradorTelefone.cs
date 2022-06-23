using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackend.Utils.Faker
{
    public static class GeradorTelefone
    {
        public static string GerarTelefone()
        {
            Random rdn = new Random();
            return rdn.Next(900000000, 999999999).ToString();
        }       

        public static int GerarDDD()
        {
            Random rdn = new Random();

            List<int> ddd = new List<int>
            {
                11, 13
            };

            return ddd[rdn.Next(ddd.Count)];
        }
    }
}

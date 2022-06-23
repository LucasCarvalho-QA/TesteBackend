using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackend.Utils.Faker
{
    public static class GeradorDocumento
    {
        public static string GerarCPF()
        {
            int sum = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string seed = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                sum += int.Parse(seed[i].ToString()) * multiplicador1[i];

            int mod = sum % 11;
            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            seed += mod;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(seed[i].ToString()) * multiplicador2[i];

            mod = sum % 11;

            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            seed += mod;
            return seed.Replace("-","").Replace(".", "");
        }

        
    }
}

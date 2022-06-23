using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackend.Utils.Faker
{
    public static class GeradorEmail
    {
        public static string GerarEmail(string chave)
        {
            return $"{chave}{SelecionarProvedor()}";
        }

        private static string SelecionarProvedor()
        {
            Random rdn = new Random();

            List<string> email = new List<string>
            {
                "@gmail.com", "@yahoo.com", "@ailos.coop.br", "@apple.com", "@outlook.com", "@uol.com.br", "@rocketmail.com", "@automationmail.com"
            };

            return $"{email[rdn.Next(email.Count)]}";
        }
    }
}

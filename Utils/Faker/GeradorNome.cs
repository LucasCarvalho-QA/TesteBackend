using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackend.Utils.Faker
{
    public static class GeradorNome
    {   
        public static string NomeCompletoMasculino()
        {            
            return $"{PrimeiroNomeMasculino()} {Sobrenome()}";
        }

        public static string NomeCompletoFeminino()
        {
            return $"{PrimeiroNomeFeminino()} {Sobrenome()}";
        }

        public static string PrimeiroNomeFeminino()
        {
            Random rdn = new Random();

            List<string> firstName = new List<string>
            {
                "Agda", "Andréia", "Alice", "Ariana", "Aline","Ariane", "Bruna","Beatriz", "Berenice", "Benedita", "Camila", "Caroline","Denise", "Eliane","Eliana", "Ester", "Eunice", "Elaine", "Jaqueline", "Larissa","Laís", "Maria", "Melissa", "Mariana","Milena", "Naiara", "Noemia","Núbia", "Paula", "Pedrina", "Patrícia", "Queila", "Rita", "Simirá","Taís","Tamilá", "Telma", "Ulisson", "Umberto", "Vicente", "Vanice", "Vera", "Zulmira","Zenira"
            };

            return $"{firstName[rdn.Next(firstName.Count)]}";
        }

        public static string PrimeiroNomeMasculino()
        {
            Random rdn = new Random();

            List<string> firstName = new List<string>
            {
                "André", "Adriano", "Abinadar","Alencar", "Alcemir", "Américo", "Bruno", "Benedito",  "Carlos", "Camilo", "Ceverino", "Denis", "Daniel", "Dorivaldo", "Darley", "Edson", "Everaldo", "Elias", "Estenio", "Etevaldo", "Euclides", "Eliezer", "Everaldo", "Eduardo", "Emanuel", "Josivaldo", "Laercío", "Leandro", "Lucas", "Lourenço",  "Marcos",  "Marcelo",  "Matheus", "Neilson", "Nilson", "Nerivaldo", "Noemia","Nilvan", "Olavo", "Oliver","Olindo", "Paulo",  "Pedro", "Pivanne",  "Quelvin", "Ronaldo","Ronan", "Romildo", "Rodolfo", "Ravier", "Romã", "Salivan", "Selton", "Tadeu","Tadeu", "Ulisson", "Umberto", "Vicente", "Valdermor", "Ziraldo"
            };

            return $"{firstName[rdn.Next(firstName.Count)]}";
        }

        public static string Sobrenome()
        {
            Random rdn = new Random();

            List<string> sobrenome = new List<string>
            {
                "Andrade Barbosa", "Barbosa Oliveira", "Oliveira da Silva", "Alves Pereira","Conceição Barbosa", "Allen Young", "Hernandez King" , "Wright Lopez" , "Hill Scott", "Green Adams","Conceição da Costa", "da Costa Oliveira", "Rodrigues de Oliveira", "Amaral Neto de Souza", "Pereira da Conceição", "Barros Neto de Andrade", "Borges de Andrade Pereira da Silva", "Batista Campos do Amaral","Cardoso de Oliveira", "Pontes Guimarães", "Dias de Jesus", "Barbos de Lima", "Gonçalves da Silva", "Gonsalves de Lima", "Pereira de Oliveira Batista", "Dias de Freitas", "Ferreira", "Garcia da Paixão", "Lima Lopes", "Jesus da Silva", "da Silva de Lima", "da Silva Gonsalves Texeira", "Fernandes de Paula Conceição", "de Paula da Silva", "Barbosa de Mello Oliveira", "Oliveira Neto Conceição da Paixão"
            };

            return $"{sobrenome[rdn.Next(sobrenome.Count)]}";
        }

        public static string Usuario()
        {
            Random rdn = new Random();

            List<string> firstName = new List<string>
            {
                "Adriano", "Abinadar","Alencar", "Alcemir", "Américo", "Bruno", "Benedito",  "Carlos", "Camilo", "Ceverino", "Denis", "Daniel", "Dorivaldo", "Darley", "Edson", "Everaldo", "Elias", "Estenio", "Etevaldo", "Euclides", "Eliezer", "Everaldo", "Eduardo", "Emanuel", "Josivaldo", "Laercío", "Leandro", "Lucas", "Lourenço",  "Marcos",  "Marcelo",  "Matheus", "Neilson", "Nilson", "Nerivaldo", "Noemia","Nilvan", "Olavo", "Oliver","Olindo", "Paulo",  "Pedro", "Pivanne",  "Quelvin", "Ronaldo","Ronan", "Romildo", "Rodolfo", "Ravier", "Roma", "Salivan", "Selton", "Tadeu","Tadeu", "Ulisson", "Umberto", "Vicente", "Valdermor", "Ziraldo",
                "Agda", "Andreia", "Alice", "Ariana", "Aline","Ariane", "Bruna","Beatriz", "Berenice", "Benedita", "Camila", "Caroline","Denise", "Eliane","Eliana", "Ester", "Eunice", "Elaine", "Jaqueline", "Larissa","Lais", "Maria", "Melissa", "Mariana","Milena", "Naiara", "Noemia","Núbia", "Paula", "Pedrina", "Patrícia", "Queila", "Rita", "Simira","Tais","Tamila", "Telma", "Ulisson", "Umberto", "Vicente", "Vanice", "Vera", "Zulmira","Zenira"
            };

            return $"{firstName[rdn.Next(firstName.Count)]}{rdn.Next(1, 99)}";
        }
    }
}

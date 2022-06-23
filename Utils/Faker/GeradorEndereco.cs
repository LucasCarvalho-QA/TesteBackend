using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackend.Utils.Faker
{
    public static class GeradorEndereco
    {
        public static string Bairro()
        {
            Random rdn = new Random();

            List<string> bairro = new List<string>
            {
                "Água Rasa","Alto de Pinheiros", "Anhanguera", "Bauru", "Fortaleza", "Teresina", "Duque de Caxias", "Aricanduva", "Artur Alvim", "Barra Funda", "Bela Vista", "Belém", "Jardim Alamo", "Carrão", "Casa Verde", "Cidade Dutra", "Freguesia do Ó", "Grajaú", "Itaim Bibi", "Ipiranga", "Guaianases", "Iguatemi", "Itaquera", "Jaguaré", "Lapa", "Liberdade", "Pari", "Penha", "Pinheiros", "República", "Rio Pequeno", "Sacomã", "Sapopemba", "Sé", "Tatuapé", "Saúde", "São Rafael", "Tucurivi", "Tremembé", "Vila Curuça", "Vila Maria", "Vila Prudente", "Vila Leopodina", "Vila Medeiros", "Vila Matilde"
            };

            return bairro[rdn.Next(bairro.Count)];
        }

        public static string Cidade()
        {
            Random rdn = new Random();

            List<string> cidade = new List<string>
            {
                "Arujá","Curitiba", "Aracaju", "Bauru", "Fortaleza", "Teresina", "Duque de Caxias", "Jaboatão dos Guararapes", "Maceió", "São Paulo", "Guarulhos", "Feira de Santana", "Santo André", "Ribeirão Preto", "Salvador", "São Bernardo do Campo", "Porto Alegre", "Goiânia", "Campinas", "São Luís", "Recife", "Osasco", "Belém", "Nova Iguaçu", "Sorocaba", "São Carlos", "Parnamirim", "Magé", "Marília", "Sete Lagoas", "Colombo", "Macaé", "Divinópolis", "Itaboraí", "Jacareí", "Itapevi", "Maracanaú", "Hortolândia", "Cachoeiro de Itapemirim", "Alvorada", "Chapecó", "Itajaí", "Cabo de Santo Agostinho", "Santa Bárbara d’Oeste"
            };

            return cidade[rdn.Next(cidade.Count)];
        }

        public static string Rua()
        {
            Random rdn = new Random();

            List<string> rua = new List<string>
            {
                "Rua Pará", "Rua Maranhão", "Rua Boa Vista", "Rua São Luiz", "Rua Alagoas", "Rua Piau", "Ariana", "Alencar", "Alcemir", "Aline", "Américo","Rua 9", "Avenida 23 Maio", "Avenida 9 de Julho","Rua Mato Grosso", "Rua Santa Maria", "Rua Santa Catarina", "Rua Amador Bueno", "Avenida Juscelino kubitschek de Oliveira", "Rua Senador Olimpio", "Avenida Goias","Avenida Tancredo Neves", "Rua Votorantim", "Rua Onório Marcéla", "Rua da Paz", "Rua 15 de Julho", "Avenida Celso Garcia", "Avenida Paz de Barro", "Rua Lagoa da Canoa", "Travessa Igaratá", "Rua Cristovam Moraes Garcia", "Vila Sargentos", "Rua Damianópolis", "Rua Caju", "Travessa Igaratá", "Rua Cuevas", "Rua Cabo Antônio Pinton", "Rua Doutor Paulo Maurício de Oliveira", "Rua Marcílio Souza", "Rua Santa Emília", "Rua Hugo Gonçalves", "Viela Itanhaem", "Rua Soldado José Wsoeck", "Rua Treze de Maio", "Rua Signa", "Rua C-Dois", "Rua Tucano", "Rua Tabocas", "Rua Clóvis da Silva", "Viela Avelino Lopes", "Rua Palestra", "Avenida Lindomar Gomes de Oliveira", "Rua Alaíde Collado Alves", "Avenida Saulle Pagnoncelli", "Rua Parati", "Rua Planaltino", "Rua Guarulhos", "Rua dos Caquis", "Rua Padre Antônio Romano", "Rua Nevada", "Rua Itapora de Goiás", "Viela Bombeiros", "Rua Sebastião Garcia", "Viela Lares", "Rua Efigênia", "Rua Frio", "Rua Mamborê", "Rua João do Araguaia", "Viela Xavier Fontoura", "Viela Itiuba", "Estrada Velha Guarulhos Arujá", "Rua Sete", "Rua Osvaldo Monti", "Viela Egito", "Rua Oscar Rossin", "Rua Capanema", "Viela Formoso", "Passagem Bocabina", "Rua Elizeu Pinhal", "Rua Cecília", "Viela Lages", "Avenida Antônio da Costa Santos", "Rua Novo Piaui", "Rua Natal Ricci", "Praça Humberto Reis Costa", "Rua Guilherme Cimieri", "Rua José Diogo", "Rua Segundo-Tenente-Aviador Aly C. de Paula", "Avenida Diorama", "Rua Q2", "Avenida João Bernardo Medeiros", "Avenida Rochedo de Minas", "Rua Raimundo Nonato", "Rua Força Pública", "Estrada Velha Guarulhos-Arujá", "Avenida Aguanil", "Avenida Projecta"
            };

            return rua[rdn.Next(rua.Count)];
        }

        public static int NumeroDeCasa()
        {
            Random rdn = new Random();

            return rdn.Next(9999);
        }
    }
}

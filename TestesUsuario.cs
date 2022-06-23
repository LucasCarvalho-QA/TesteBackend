using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestBackend.Setup;
using TestBackend.Utils;
using TesteBackend.Controller;
using TesteBackend.Model;

namespace TesteBackend
{

    [TestFixture, Category("Usuario")]
    public class TestesUsuario : SetupTest
    {
        UsuarioRequest usuarioRequest = new UsuarioRequest();
        UsuarioController usuario = new UsuarioController();
        Runner runner = new Runner();

        [TestCase(TestName = "Criar usuário - Sucesso")]
        public void CriarUsuario_Sucesso()
        {
            //Arrange - Os pré requisitos do teste
            UsuarioRequest bodyRequest = usuarioRequest.RetornarRequisicao();

            //Act - De fato vamos fazer nosso teste            
            IRestResponse response = runner.ExecuteRestCall(Method.POST, null, bodyRequest);

            //Assert - Onde fazemos as nossas validações
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);   
        }

        [TestCase(TestName = "Selecionar usuário - Sucesso")]
        public void SelecionarUsuario_Sucesso()
        {
            //Arrange            
            UsuarioRequest usuarioRecemCriado = usuario.CriarUsuario_Sucesso();

            //Act
            IRestResponse response = runner.ExecuteRestCall(Method.GET, usuarioRecemCriado.id);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase(TestName = "Atualizar usuário - Sucesso")]
        public void AtualizarUsuario()
        {
            //Arrange
            UsuarioRequest bodyRequest = usuarioRequest.RetornarRequisicao();
            bodyRequest.status = "inactive";
            UsuarioRequest usuarioRecemCriado = usuario.CriarUsuario_Sucesso();

            //Act
            IRestResponse response = runner.ExecuteRestCall(Method.PATCH, usuarioRecemCriado.id, bodyRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase(TestName = "Exluir usuário - Sucesso")]
        public void ExcluirUsuario_Sucesso()
        {
            //Arrange
            UsuarioRequest usuarioRecemCriado = usuario.CriarUsuario_Sucesso();

            //Act
            IRestResponse response = runner.ExecuteRestCall(Method.DELETE, usuarioRecemCriado.id);

            //Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestCase(TestName = "Criar usuário - Email existente")]
        public void CriarUsuario_EmailExistente()
        {
            //Arrange - Os pré requisitos do teste
            UsuarioRequest bodyRequest = usuarioRequest.RetornarRequisicao();

            //Act - De fato vamos fazer nosso teste            
            runner.ExecuteRestCall(Method.POST, null, bodyRequest);
            IRestResponse response = runner.ExecuteRestCall(Method.POST, null, bodyRequest);

            //Assert - Onde fazemos as nossas validações
            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestCase(TestName = "Criar usuário - Sucesso 2")]
        public void CriarUsuario_Sucesso2()
        {
            //Arrange - Os pré requisitos do teste
            UsuarioRequest bodyRequest = usuarioRequest.RetornarRequisicao();

            //Act - De fato vamos fazer nosso teste            
            IRestResponse response = runner.ExecuteRestCall(Method.POST, null, bodyRequest);

            //Assert - Onde fazemos as nossas validações
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }


        [TestCase(TestName = "Criar usuário - Sucesso 32")]
        public void CriarUsuario_Sucesso32()
        {
            //Arrange - Os pré requisitos do teste
            UsuarioRequest bodyRequest = usuarioRequest.RetornarRequisicao();

            //Act - De fato vamos fazer nosso teste            
            IRestResponse response = runner.ExecuteRestCall(Method.POST, null, bodyRequest);

            //Assert - Onde fazemos as nossas validações
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

    }
}

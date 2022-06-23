using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TestBackend.Utils;
using TesteBackend.Model;

namespace TesteBackend.Controller
{
    public class UsuarioController
    {
        UsuarioRequest usuarioRequest = new UsuarioRequest();
        Runner runner = new Runner();

        public UsuarioRequest CriarUsuario_Sucesso()
        {
            UsuarioRequest requisicao = usuarioRequest.RetornarRequisicao();

            IRestResponse response = runner.ExecuteRestCall(Method.POST, null, requisicao, null, true);

            return JsonConvert.DeserializeObject<UsuarioRequest>(response.Content);
        }
        
    }
}

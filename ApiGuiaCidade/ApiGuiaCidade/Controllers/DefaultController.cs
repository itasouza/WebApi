using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiGuiaCidade.Dominio;
using ApiGuiaCidade.Aplicacao;


namespace ApiGuiaCidade.Controllers
{

    [RoutePrefix("api/ApiGuiaCidade")]
    public class DefaultController : ApiController
    {


        //http://localhost:1608/api/ApiGuiaCidade/clientes/todos
        [HttpGet]
        [Route("clientes/todos")]
        public HttpResponseMessage ClientesTodos()
        {
            try
            {
                var tCliente = new ClienteAplicacao();
                var listarDeClientes = tCliente.ListarTodos();
                return Request.CreateResponse(HttpStatusCode.OK, listarDeClientes.ToArray());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        //http://localhost:1608/api/ApiGuiaCidade/consulta/clientePorID/1
        [HttpGet]
        [Route("consulta/clientePorID/{id:int}")]
        public HttpResponseMessage ClientePorID(int id)
        {
            try
            {
                var tCliente = new ClienteAplicacao();
                var listarDeClientes = tCliente.ListarPoId(id);
                return Request.CreateResponse(HttpStatusCode.OK, listarDeClientes);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }    
        }

        //http://localhost:1608/api/ApiGuiaCidade/consulta/clientePorNome/e
        [HttpGet]
        [Route("consulta/clientePorNome/{nome:alpha}")]
        public HttpResponseMessage ClientePorNome(string nome)
        {
            try
            {
                var tCliente = new ClienteAplicacao();
                var listarDeClientes = tCliente.ListarPorNome(nome);
                return Request.CreateResponse(HttpStatusCode.OK, listarDeClientes.ToArray());
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        //http://localhost:1608/api/ApiGuiaCidade/consulta/clienteLoginSenha/teste@teste.com.br/teste
        [HttpGet]
        [Route("consulta/clienteLoginSenha/{email}/{senha}")]
        public HttpResponseMessage ClientePorLoginSenha(string email, string senha)
        {
            try
            {
                var tCliente = new ClienteAplicacao();
                var listarDeClientes = tCliente.ListarPorLoginSenha(email,senha);
                return Request.CreateResponse(HttpStatusCode.OK, listarDeClientes.ToArray());
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        //http://localhost:1608/api/ApiGuiaCidade/deletar/cliente/10
        //precisa usar o postman com opção delete formato json
        [HttpDelete]
        [Route("deletar/cliente/{id:int}")]
        public HttpResponseMessage ClienteDeletar(int id)
        {
            try
            {
                var tCliente = new ClienteAplicacao();
                var resultado = tCliente.Excluir(id);
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        //http://localhost:1608/api/ApiGuiaCidade/datahora/consulta
        [HttpGet]
        [Route("datahora/consulta")]
        public HttpResponseMessage GetDataHoraServidor()
        {
            try
            {
                var dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                return Request.CreateResponse(HttpStatusCode.OK, dataHora);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //http://localhost:1608/api/ApiGuiaCidade/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage CadastroCadastro(Cliente cliente)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, "cadastro do cliente " + cliente.Nome + " realizado");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //{ exemplo de uso
        // "Nome":"nome de teste",
        // "DataNascimento":"2014-01-02 00:00:00.000",
        // "Email":"teste@teste.com.br",
        // "senha":"12456"
        //}

        //http://localhost:1608/api/ApiGuiaCidade/cadastrar/cliente
        //"Referência de objeto não definida para uma instância de um objeto."
        [HttpPost]
        [Route("cadastrar/cliente/")]
        public HttpResponseMessage PostCadastro(Cliente cliente)
        {
            try
            {
                var tCliente = new ClienteAplicacao();
                tCliente.Inseri(cliente);
                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro do cliente" + cliente.Nome + "realizado.");
            }
            catch (Exception ex )
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using ApiGuiaCidade.Dominio;
using ApiGuiaCidade.Repositorio;
using System.Data.SqlClient;

namespace ApiGuiaCidade.Aplicacao
{
    public class ClienteAplicacao
    {
        private Contexto contexto;

     
        public List<Cliente> ListarTodos()
        {
            var strQuery = "select id, nome, data_nascimento, email from clientes";

            using (contexto = new Contexto())
            {
               var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
               return TransformaReaderEmListaObjetos(retornoDataReader);
            }

        }

        public List<Cliente> ListarPorNome(string nome)
        {
            var strQuery = string.Format("select * from clientes where nome like '{0}%' ", nome);
            using (contexto = new Contexto())
            {
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaObjetos(retornoDataReader);
            }

        }


        public List<Cliente> ListarPorLoginSenha(string email,string senha)
        {
            var strQuery = string.Format("select * from clientes where email = '{0}' and senha = '{1}' ", email, senha);
            using (contexto = new Contexto())
            {
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaObjetos(retornoDataReader);
            }

        }


        public Cliente ListarPoId(int id)
        {
            var strQuery = string.Format("select * from clientes where Id = {0}", id);

            using (contexto = new Contexto())
            {
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaObjetos(retornoDataReader).FirstOrDefault();
            }
        }


        public void Inseri(Cliente cliente)
        {
            var strQuery = "";
            strQuery += "INSERT INTO CLIENTES (NOME, DATA_NASCIMENTO,EMAIL, SENHA)";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}' )", cliente.Nome, cliente.DataNascimento, cliente.Email, cliente.senha);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }

        }


        private void Alterar(Cliente cliente)
        {

            var strQuery = "";
            strQuery += "UPDATE CLIENTES SET";
            strQuery += string.Format(" NOME = '{0}', ", cliente.Nome);
            strQuery += string.Format(" DATA_NASCIMENTO = '{0}', ", cliente.DataNascimento);
            strQuery += string.Format(" EMAIL = '{0}' ", cliente.Email);
            strQuery += string.Format(" SEMHA = '{0}' ", cliente.senha);
            strQuery += string.Format(" WHERE IDALUNO= '{0}' ", cliente.Id);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }


        public void Salvar(Cliente cliente)
        {
            if (cliente.Id > 0)
                Alterar(cliente);
            else
                Inseri(cliente);

        }


        public bool Excluir(int id)
        {
            var retorno = 0;
            var strQuery = string.Format("DELETE FROM clientes WHERE id= {0}; SELECT id FROM clientes WHERE id = {0}", id);
            using (contexto = new Contexto())
            {
                var reader = contexto.ExecutaComandoComRetorno(strQuery);
                while (reader.Read())
                {
                    retorno = Convert.ToInt32(reader["id"]);
                }
                reader.Close();
            }

            if (retorno == 0)
                return true;
            return false;
        }



        private List<Cliente> TransformaReaderEmListaObjetos(SqlDataReader reader)
        {
            var clientes = new List<Cliente>();
            while (reader.Read())
            {

                Cliente cliente = new Cliente()
                {
                    Id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]),
                    Nome = reader["nome"] == DBNull.Value ? string.Empty : reader["nome"].ToString(),
                    DataNascimento = reader["data_nascimento"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["data_nascimento"]),
                    Email = reader["email"] == DBNull.Value ? string.Empty : reader["email"].ToString()

                };

                clientes.Add(cliente);
            }
            reader.Close();
            return clientes;
        }


    }
}

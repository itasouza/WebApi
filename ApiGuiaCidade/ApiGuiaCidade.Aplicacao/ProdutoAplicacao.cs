using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiGuiaCidade.Dominio;
using ApiGuiaCidade.Repositorio;
using System.Data.SqlClient;

namespace ApiGuiaCidade.Aplicacao
{
     public class ProdutoAplicacao
    {
        private Contexto contexto;

        public List<Produto> ListarTodos()
        {
            var strQuery = "select * from email from produto";

            using (contexto = new Contexto())
            {
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaObjetos(retornoDataReader);
            }

        }


        private List<Produto> TransformaReaderEmListaObjetos(SqlDataReader reader)
        {
            var produtos = new List<Produto>();
            while (reader.Read())
            {

                Produto produto = new Produto()
                {
                    //Id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]),
                    //Nome = reader["nome"] == DBNull.Value ? string.Empty : reader["nome"].ToString(),
                    //DataNascimento = reader["data_nascimento"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["data_nascimento"]),
                    //Email = reader["email"] == DBNull.Value ? string.Empty : reader["email"].ToString()

                };

               produtos.Add(produto);
            }
            reader.Close();
            return produtos;
        }

    }
}

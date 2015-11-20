using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGuiaCidade.Dominio
{
    public class Produto
    {

        public int controleproduto { get; set; }
        public int controleunidade { get; set; }
        public string descricaounidade { get; set; }
        public int controlegrupo { get; set; }
        public string descricaogrupo { get; set; }
        public int controlesubgrupo { get; set; }
        public string descricaosubgrupo { get; set; }
        public string descricaoproduto { get; set; }
        public string nomeempresa { get; set; } 
	    public string codigocomercial { get; set; }
        public DateTime dataultimaconferencia { get; set; }
        public int controleempresa { get; set; }
        public string observacao { get; set; }
        public string status { get; set; }
        public string marca { get; set; }
        public DateTime data_inc { get; set; }
        public DateTime data_hab { get; set; }
        public DateTime data_alt { get; set; }
        public int controleusuario { get; set; }
        public int controleimagem { get; set; }
        public double pesoliquido { get; set; }
        public double pesobruto { get; set; }
        public int codigoncm { get; set; }
        public string sittributaria { get; set; }
        public double ipi { get; set; }
        public double creditopis { get; set; }
        public double creditocofins { get; set; }
        public double qtdestoque { get; set; }
        public double qtdestoqueantigo { get; set; }
        public string localizacao { get; set; }
        public int codigoca { get; set; }
        public double estoqueminimo { get; set; }
        public double precoreposicao { get; set; }
        public DateTime dataprecoreposicao { get; set; }
        public double customediocontabil { get; set; }
        public double valorultimaentrada { get; set; }
        public double dataultimaentrada { get; set; }
        public double precovenda { get; set; }
        public DateTime dataprecovenda { get; set; }
        public DateTime datadevalidade { get; set; }
        public int controlecliente { get; set; }
        public string nomefornecedor { get; set; }
        public string codigobarras { get; set; }
        public string nomemarca { get; set; }
        public string refmarca { get; set; }
    }
}

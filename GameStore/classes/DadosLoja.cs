using System;
using System.Collections.Generic;

namespace GameStore.Classes
{
    public class DadosLoja
    {
        public List<JogoSalvo> Jogos { get; set; }
        public List<ClienteSalvo> Clientes { get; set; }
        public List<VendaSalva> Vendas { get; set; }
        public List<SolicitacaoSalva> Solicitacoes { get; set; }

        public DadosLoja()
        {
            Jogos = new List<JogoSalvo>();
            Clientes = new List<ClienteSalvo>();
            Vendas = new List<VendaSalva>();
            Solicitacoes = new List<SolicitacaoSalva>();
        }
    }

    public class JogoSalvo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string Plataforma { get; set; }
        public string Genero { get; set; }
        public int ClassificacaoIndicativa { get; set; }
    }

    public class ClienteSalvo
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }

    public class VendaSalva
    {
        public int Id { get; set; }
        public string EmailCliente { get; set; }
        public int IdJogo { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataVenda { get; set; }
    }

    public class SolicitacaoSalva
    {
        public int Id { get; set; }
        public string EmailCliente { get; set; }
        public string NomeJogo { get; set; }
        public string Plataforma { get; set; }
        public DateTime DataSolicitacao { get; set; }
    }
}
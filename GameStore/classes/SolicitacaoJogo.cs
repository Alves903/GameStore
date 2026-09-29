using System;

namespace GameStore.Classes
{
    public class SolicitacaoJogo
    {
        private static int proximoId = 1;
        private string nomeJogo = "";
        private string plataforma = "";

        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public DateTime DataSolicitacao { get; private set; }

        public string NomeJogo
        {
            get { return nomeJogo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome do jogo não pode ficar vazio.");

                nomeJogo = value.Trim();
            }
        }

        public string Plataforma
        {
            get { return plataforma; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A plataforma não pode ficar vazia.");

                plataforma = value.Trim();
            }
        }

        private SolicitacaoJogo()
        {
        }

        public SolicitacaoJogo(Cliente cliente, string nomeJogo, string plataforma)
        {
            if (cliente == null)
                throw new ArgumentNullException("cliente");

            Id = proximoId++;
            Cliente = cliente;
            NomeJogo = nomeJogo;
            Plataforma = plataforma;
            DataSolicitacao = DateTime.Now;
        }

        public void Apresentar()
        {
            Console.WriteLine("Solicitação: " + Id);
            Console.WriteLine("Cliente: " + Cliente.Nome);
            Console.WriteLine("Jogo pedido: " + NomeJogo);
            Console.WriteLine("Plataforma: " + Plataforma);
            Console.WriteLine("Data: " + DataSolicitacao.ToString("dd/MM/yyyy"));
        }

        public static SolicitacaoJogo Restaurar(
            int id,
            Cliente cliente,
            string nomeJogo,
            string plataforma,
            DateTime dataSolicitacao)
        {
            if (cliente == null)
                throw new ArgumentNullException("cliente");

            SolicitacaoJogo solicitacao = new SolicitacaoJogo();

            solicitacao.Id = id;
            solicitacao.Cliente = cliente;
            solicitacao.NomeJogo = nomeJogo;
            solicitacao.Plataforma = plataforma;
            solicitacao.DataSolicitacao = dataSolicitacao;

            if (id >= proximoId)
                proximoId = id + 1;

            return solicitacao;
        }
    }
}
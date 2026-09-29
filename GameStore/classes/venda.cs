using System;

namespace GameStore.Classes
{
    public class Venda : IVendavel
    {
        private static int proximoId = 1;
        private bool finalizada;

        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public Jogo Jogo { get; private set; }
        public int Quantidade { get; private set; }
        public DateTime DataVenda { get; private set; }

        private Venda()
        {
        }

        public Venda(Cliente cliente, Jogo jogo, int quantidade)
        {
            if (cliente == null)
                throw new ArgumentNullException("cliente");

            if (jogo == null)
                throw new ArgumentNullException("jogo");

            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            if (jogo.QuantidadeEstoque < quantidade)
                throw new InvalidOperationException("Não há estoque suficiente.");

            Id = proximoId++;
            Cliente = cliente;
            Jogo = jogo;
            Quantidade = quantidade;
            DataVenda = DateTime.Now;
            finalizada = false;
        }

        public decimal CalcularTotal()
        {
            return Jogo.Preco * Quantidade;
        }

        public void FinalizarVenda()
        {
            if (finalizada)
                throw new InvalidOperationException("Essa venda já foi finalizada.");

            if (Jogo.QuantidadeEstoque < Quantidade)
                throw new InvalidOperationException("Não há estoque suficiente.");

            Jogo.QuantidadeEstoque -= Quantidade;
            finalizada = true;

            Console.WriteLine("Venda finalizada!");
            Console.WriteLine("Total: R$ " + CalcularTotal().ToString("F2"));
        }

        public static Venda Restaurar(
            int id,
            Cliente cliente,
            Jogo jogo,
            int quantidade,
            DateTime dataVenda)
        {
            if (cliente == null)
                throw new ArgumentNullException("cliente");

            if (jogo == null)
                throw new ArgumentNullException("jogo");

            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            Venda venda = new Venda();

            venda.Id = id;
            venda.Cliente = cliente;
            venda.Jogo = jogo;
            venda.Quantidade = quantidade;
            venda.DataVenda = dataVenda;
            venda.finalizada = true;

            if (id >= proximoId)
                proximoId = id + 1;

            return venda;
        }
    }
}
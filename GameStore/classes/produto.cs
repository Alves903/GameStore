using System;

namespace GameStore.Classes
{
    public abstract class Produto
    {
        private string nome = "";
        private decimal preco;
        private int quantidadeEstoque;
        private static int proximoId = 1;
        public static int QuantidadeProdutos { get; private set; }
        public int Id { get; set; }
        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O nome do produto não pode ficar vazio.");
                }

                nome = value.Trim();
            }
        }

        public decimal Preco
        {
            get { return preco; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("O preço não pode ser negativo.");
                }

                preco = value;
            }
        }

        public int QuantidadeEstoque
        {
            get { return quantidadeEstoque; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("O estoque não pode ser negativo.");
                }

                quantidadeEstoque = value;
            }
        }

        public Produto()
        {
            this.Id = proximoId;
            proximoId++;
            QuantidadeProdutos++;
        }

        public Produto(string nome, decimal preco, int quantidadeEstoque)
            : this()
        {
            this.Nome = nome;
            this.Preco = preco;
            this.QuantidadeEstoque = quantidadeEstoque;
        }

        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new ArgumentException("A quantidade precisa ser maior que zero.");
            }

            this.QuantidadeEstoque += quantidade;
        }

        public void RegistrarSaidaEstoque(int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new ArgumentException("A quantidade precisa ser maior que zero.");
            }

            if (quantidade > this.QuantidadeEstoque)
            {
                throw new InvalidOperationException("Não há estoque suficiente.");
            }

            this.QuantidadeEstoque -= quantidade;
        }

        public bool EstoqueEstaBaixo(int limite)
        {
            return this.QuantidadeEstoque <= limite;
        }

        public static void AtualizarProximoId(int id)
        {
            if (id >= proximoId)
            {
                proximoId = id + 1;
            }
        }

        public abstract void Apresentar();
    }
}
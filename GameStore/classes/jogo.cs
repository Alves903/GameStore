using System;

namespace GameStore.Classes
{
    public class Jogo : Produto
    {
        private string plataforma = "";
        private string genero = "";
        private int classificacaoIndicativa;
        public string Plataforma
        {
            get { return plataforma; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A plataforma não pode ficar vazia.");
                }

                plataforma = value.Trim();
            }
        }

        public string Genero
        {
            get { return genero; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O gênero não pode ficar vazio.");
                }

                genero = value.Trim();
            }
        }

        public int ClassificacaoIndicativa
        {
            get { return classificacaoIndicativa; }
            set
            {
                if (value < 0 || value > 18)
                {
                    throw new ArgumentException("A classificação deve estar entre 0 e 18 anos.");
                }

                classificacaoIndicativa = value;
            }
        }

        public Jogo(
            string nome,
            decimal preco,
            int quantidadeEstoque,
            string plataforma,
            string genero,
            int classificacaoIndicativa)
            : base(nome, preco, quantidadeEstoque)
        {
            this.Plataforma = plataforma;
            this.Genero = genero;
            this.ClassificacaoIndicativa = classificacaoIndicativa;
        }

        public override void Apresentar()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("       DADOS DO JOGO");
            Console.WriteLine("==============================");
            Console.WriteLine("ID: " + this.Id);
            Console.WriteLine("Nome: " + this.Nome);
            Console.WriteLine("Preço: " + this.Preco.ToString("C2"));
            Console.WriteLine("Estoque: " + this.QuantidadeEstoque);
            Console.WriteLine("Plataforma: " + this.Plataforma);
            Console.WriteLine("Gênero: " + this.Genero);
            Console.WriteLine("Classificação: " + this.ClassificacaoIndicativa + " anos");
            Console.WriteLine("------------------------------");
        }
    }
}
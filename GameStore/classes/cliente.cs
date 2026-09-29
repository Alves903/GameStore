using System;

namespace GameStore.Classes
{
    public class Cliente : Pessoa
    {
        private string telefone;
        public string Telefone
        {
            get { return telefone; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O telefone não pode ficar vazio.");

                telefone = value;
            }
        }

        public Cliente(string nome, string email, string telefone)
            : base(nome, email)
        {
            this.Telefone = telefone;
        }

        public override void Apresentar()
        {
            Console.WriteLine("Cliente: " + Nome);
            Console.WriteLine("E-mail: " + Email);
            Console.WriteLine("Telefone: " + Telefone);
        }
    }
}
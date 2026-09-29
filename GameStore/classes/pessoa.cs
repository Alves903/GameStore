using System;

namespace GameStore.Classes
{
    public abstract class Pessoa
    {
        private string nome;
        private string email;
        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome não pode ficar vazio.");

                nome = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O e-mail não pode ficar vazio.");

                email = value;
            }
        }

        protected Pessoa(string nome, string email)
        {
            this.Nome = nome;
            this.Email = email;
        }

        public abstract void Apresentar();
    }
}
using System;
using System.Collections.Generic;
using GameStore.Classes;
using System.IO;

namespace GameStore
{
    internal class Program
    {
        static List<Jogo> jogos = new List<Jogo>();
        static List<Cliente> clientes = new List<Cliente>();
        static List<Venda> vendas = new List<Venda>();
        static List<SolicitacaoJogo> solicitacoes = new List<SolicitacaoJogo>();

        static void Main(string[] args)
        {
            int opcao = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("===== GAME STORE =====");
                Console.WriteLine("1 - Jogos");
                Console.WriteLine("2 - Clientes");
                Console.WriteLine("3 - Vendas");
                Console.WriteLine("4 - Pedidos de jogos");
                Console.WriteLine("5 - Salvar dados");
                Console.WriteLine("6 - Carregar dados");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        MenuJogos();
                        break;

                    case 2:
                        MenuClientes();
                        break;

                    case 3:
                        MenuVendas();
                        break;

                    case 4:
                        MenuSolicitacoes();
                        break;

                    case 5:
                        SalvarDados();
                        Aguardar();
                        break;

                    case 6:
                        CarregarDados();
                        Aguardar();
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Aguardar();
                        break;
                }
            }
            while (opcao != 0);
        }

        static void MenuJogos()
        {
            int opcao = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("===== MENU DE JOGOS =====");
                Console.WriteLine("1 - Cadastrar jogo");
                Console.WriteLine("2 - Listar jogos");
                Console.WriteLine("3 - Pesquisar jogo");
                Console.WriteLine("4 - Excluir jogo");
                Console.WriteLine("5 - Ver jogos com estoque baixo");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarJogo();
                        Aguardar();
                        break;

                    case 2:
                        ListarJogos();
                        Aguardar();
                        break;

                    case 3:
                        PesquisarJogo();
                        Aguardar();
                        break;

                    case 4:
                        ExcluirJogo();
                        Aguardar();
                        break;

                    case 5:
                        ListarJogosComEstoqueBaixo();
                        Aguardar();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Aguardar();
                        break;
                }
            }
            while (opcao != 0);
        }

        static void MenuClientes()
        {
            int opcao = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("===== MENU DE CLIENTES =====");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Listar clientes");
                Console.WriteLine("3 - Pesquisar cliente");
                Console.WriteLine("4 - Excluir cliente");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarCliente();
                        Aguardar();
                        break;

                    case 2:
                        ListarClientes();
                        Aguardar();
                        break;

                    case 3:
                        PesquisarCliente();
                        Aguardar();
                        break;

                    case 4:
                        ExcluirCliente();
                        Aguardar();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Aguardar();
                        break;
                }
            }
            while (opcao != 0);
        }

        static void MenuVendas()
        {
            int opcao = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("===== MENU DE VENDAS =====");
                Console.WriteLine("1 - Registrar venda");
                Console.WriteLine("2 - Listar vendas");
                Console.WriteLine("3 - Relatório de vendas");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        RegistrarVenda();
                        Aguardar();
                        break;

                    case 2:
                        ListarVendas();
                        Aguardar();
                        break;

                    case 3:
                        ExibirRelatorioVendas();
                        Aguardar();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Aguardar();
                        break;
                }
            }
            while (opcao != 0);
        }

        static void MenuSolicitacoes()
        {
            int opcao = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("===== PEDIDOS DE JOGOS =====");
                Console.WriteLine("1 - Registrar pedido");
                Console.WriteLine("2 - Listar pedidos");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarSolicitacaoJogo();
                        Aguardar();
                        break;

                    case 2:
                        ListarSolicitacoes();
                        Aguardar();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Aguardar();
                        break;
                }
            }
            while (opcao != 0);
        }

        static void CadastrarSolicitacaoJogo()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===== REGISTRAR PEDIDO DE JOGO =====");

                if (clientes.Count == 0)
                {
                    Console.WriteLine("Cadastre um cliente antes de registrar um pedido.");
                    return;
                }

                Console.WriteLine("Clientes:");

                for (int i = 0; i < clientes.Count; i++)
                {
                    Console.WriteLine((i + 1) + " - " + clientes[i].Nome);
                }

                Console.Write("Escolha o número do cliente: ");

                if (!int.TryParse(Console.ReadLine(), out int numeroCliente)
                    || numeroCliente < 1
                    || numeroCliente > clientes.Count)
                {
                    Console.WriteLine("Número de cliente inválido.");
                    return;
                }

                Console.Write("Nome do jogo desejado: ");
                string nomeJogo = Console.ReadLine() ?? "";

                Console.Write("Plataforma desejada: ");
                string plataforma = Console.ReadLine() ?? "";

                Cliente clienteSelecionado = clientes[numeroCliente - 1];

                SolicitacaoJogo solicitacao = new SolicitacaoJogo(
                    clienteSelecionado,
                    nomeJogo,
                    plataforma
                );

                solicitacoes.Add(solicitacao);

                Console.WriteLine("Pedido registrado com sucesso!");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro ao registrar o pedido: " + erro.Message);
            }
        }

        static void ListarSolicitacoes()
        {
            Console.Clear();
            Console.WriteLine("===== PEDIDOS REGISTRADOS =====");

            if (solicitacoes.Count == 0)
            {
                Console.WriteLine("Ainda não há pedidos registrados.");
                return;
            }

            foreach (SolicitacaoJogo solicitacao in solicitacoes)
            {
                solicitacao.Apresentar();
                Console.WriteLine("----------------------------");
            }
        }

        static void CadastrarJogo()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===== CADASTRAR JOGO =====");

                Console.Write("Nome do jogo: ");
                string nome = Console.ReadLine() ?? "";

                Console.Write("Preço: ");
                decimal preco = decimal.Parse(Console.ReadLine() ?? "");

                Console.Write("Quantidade em estoque: ");
                int quantidade = int.Parse(Console.ReadLine() ?? "");

                Console.Write("Plataforma: ");
                string plataforma = Console.ReadLine() ?? "";

                Console.Write("Gênero: ");
                string genero = Console.ReadLine() ?? "";

                Console.Write("Classificação indicativa: ");
                int classificacao = int.Parse(Console.ReadLine() ?? "");

                Jogo jogo = new Jogo(
                    nome,
                    preco,
                    quantidade,
                    plataforma,
                    genero,
                    classificacao
                );

                jogos.Add(jogo);
                Console.WriteLine("\nJogo cadastrado com sucesso!");
            }
            catch (Exception erro)
            {
                Console.WriteLine("\nErro ao cadastrar o jogo: " + erro.Message);
            }
        }

        static void ListarJogos()
        {
            Console.Clear();
            Console.WriteLine("===== JOGOS CADASTRADOS =====");

            if (jogos.Count == 0)
            {
                Console.WriteLine("Ainda não há jogos cadastrados.");
                return;
            }

            foreach (Jogo jogo in jogos)
            {
                jogo.Apresentar();
                Console.WriteLine("----------------------------");
            }
        }

        static void ListarJogosComEstoqueBaixo()
        {
            Console.Clear();
            Console.WriteLine("===== JOGOS COM ESTOQUE BAIXO =====");

            if (jogos.Count == 0)
            {
                Console.WriteLine("Ainda não há jogos cadastrados.");
                return;
            }

            bool encontrou = false;

            foreach (Jogo jogo in jogos)
            {
                if (jogo.EstoqueEstaBaixo(2))
                {
                    jogo.Apresentar();
                    Console.WriteLine("----------------------------");
                    encontrou = true;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Nenhum jogo está com estoque baixo.");
            }
        }

        static void PesquisarJogo()
        {
            Console.Clear();
            Console.WriteLine("===== PESQUISAR JOGO =====");

            if (jogos.Count == 0)
            {
                Console.WriteLine("Ainda não há jogos cadastrados.");
                return;
            }

            Console.Write("Digite o nome ou parte do nome do jogo: ");
            string busca = Console.ReadLine() ?? "";

            bool encontrou = false;

            foreach (Jogo jogo in jogos)
            {
                if (jogo.Nome.IndexOf(busca, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    jogo.Apresentar();
                    Console.WriteLine("----------------------------");
                    encontrou = true;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Nenhum jogo encontrado.");
            }
        }

        static void ExcluirJogo()
        {
            Console.Clear();
            Console.WriteLine("===== EXCLUIR JOGO =====");

            if (jogos.Count == 0)
            {
                Console.WriteLine("Ainda não há jogos cadastrados.");
                return;
            }

            foreach (Jogo jogo in jogos)
            {
                Console.WriteLine("ID: " + jogo.Id + " - " + jogo.Nome);
            }

            Console.Write("\nDigite o ID do jogo que deseja excluir: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Digite um ID válido.");
                return;
            }

            for (int i = 0; i < jogos.Count; i++)
            {
                if (jogos[i].Id == id)
                {
                    jogos.RemoveAt(i);
                    Console.WriteLine("Jogo excluído com sucesso.");
                    return;
                }
            }

            Console.WriteLine("Não foi encontrado um jogo com esse ID.");
        }

        static void CadastrarCliente()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===== CADASTRAR CLIENTE =====");

                Console.Write("Nome: ");
                string nome = Console.ReadLine() ?? "";

                Console.Write("E-mail: ");
                string email = Console.ReadLine() ?? "";

                Console.Write("Telefone: ");
                string telefone = Console.ReadLine() ?? "";

                Cliente cliente = new Cliente(nome, email, telefone);
                clientes.Add(cliente);

                Console.WriteLine("\nCliente cadastrado com sucesso!");
            }
            catch (Exception erro)
            {
                Console.WriteLine("\nErro ao cadastrar o cliente: " + erro.Message);
            }
        }

        static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("===== CLIENTES CADASTRADOS =====");

            if (clientes.Count == 0)
            {
                Console.WriteLine("Ainda não há clientes cadastrados.");
                return;
            }

            foreach (Cliente cliente in clientes)
            {
                cliente.Apresentar();
                Console.WriteLine("----------------------------");
            }
        }

        static void PesquisarCliente()
        {
            Console.Clear();
            Console.WriteLine("===== PESQUISAR CLIENTE =====");

            if (clientes.Count == 0)
            {
                Console.WriteLine("Ainda não há clientes cadastrados.");
                return;
            }

            Console.Write("Digite o nome ou parte do nome do cliente: ");
            string busca = Console.ReadLine() ?? "";

            bool encontrou = false;

            foreach (Cliente cliente in clientes)
            {
                if (cliente.Nome.IndexOf(busca, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    cliente.Apresentar();
                    Console.WriteLine("----------------------------");
                    encontrou = true;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Nenhum cliente encontrado.");
            }
        }

        static void ExcluirCliente()
        {
            Console.Clear();
            Console.WriteLine("===== EXCLUIR CLIENTE =====");

            if (clientes.Count == 0)
            {
                Console.WriteLine("Ainda não há clientes cadastrados.");
                return;
            }

            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine(cliente.Nome + " - " + cliente.Email);
            }

            Console.Write("\nDigite o e-mail do cliente que deseja excluir: ");
            string email = Console.ReadLine() ?? "";

            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    clientes.RemoveAt(i);
                    Console.WriteLine("Cliente excluído com sucesso.");
                    return;
                }
            }

            Console.WriteLine("Não foi encontrado um cliente com esse e-mail.");
        }

        static void RegistrarVenda()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===== REGISTRAR VENDA =====");

                if (clientes.Count == 0)
                {
                    Console.WriteLine("Cadastre um cliente antes de registrar uma venda.");
                    return;
                }

                if (jogos.Count == 0)
                {
                    Console.WriteLine("Cadastre um jogo antes de registrar uma venda.");
                    return;
                }

                Console.WriteLine("\nClientes:");

                for (int i = 0; i < clientes.Count; i++)
                {
                    Console.WriteLine((i + 1) + " - " + clientes[i].Nome);
                }

                Console.Write("Escolha o número do cliente: ");
                int numeroCliente = int.Parse(Console.ReadLine() ?? "");

                if (numeroCliente < 1 || numeroCliente > clientes.Count)
                {
                    Console.WriteLine("Número de cliente inválido.");
                    return;
                }

                Console.WriteLine("\nJogos:");

                for (int i = 0; i < jogos.Count; i++)
                {
                    Console.WriteLine(
                        (i + 1) + " - " + jogos[i].Nome
                        + " | Estoque: " + jogos[i].QuantidadeEstoque
                    );
                }

                Console.Write("Escolha o número do jogo: ");
                int numeroJogo = int.Parse(Console.ReadLine() ?? "");

                if (numeroJogo < 1 || numeroJogo > jogos.Count)
                {
                    Console.WriteLine("Número de jogo inválido.");
                    return;
                }

                Console.Write("Quantidade: ");
                int quantidade = int.Parse(Console.ReadLine() ?? "");

                Cliente clienteSelecionado = clientes[numeroCliente - 1];
                Jogo jogoSelecionado = jogos[numeroJogo - 1];

                Venda venda = new Venda(
                    clienteSelecionado,
                    jogoSelecionado,
                    quantidade
                );

                venda.FinalizarVenda();
                vendas.Add(venda);
            }
            catch (Exception erro)
            {
                Console.WriteLine("\nErro ao registrar a venda: " + erro.Message);
            }
        }

        static void ListarVendas()
        {
            Console.Clear();
            Console.WriteLine("===== VENDAS REGISTRADAS =====");

            if (vendas.Count == 0)
            {
                Console.WriteLine("Ainda não há vendas registradas.");
                return;
            }

            foreach (Venda venda in vendas)
            {
                Console.WriteLine("Venda: " + venda.Id);
                Console.WriteLine("Cliente: " + venda.Cliente.Nome);
                Console.WriteLine("Jogo: " + venda.Jogo.Nome);
                Console.WriteLine("Quantidade: " + venda.Quantidade);
                Console.WriteLine("Total: " + venda.CalcularTotal().ToString("C2"));
                Console.WriteLine("Data: " + venda.DataVenda.ToString("dd/MM/yyyy HH:mm"));
                Console.WriteLine("----------------------------");
            }
        }

        static void ExibirRelatorioVendas()
        {
            Console.Clear();
            Console.WriteLine("===== RELATÓRIO DE VENDAS =====");

            if (vendas.Count == 0)
            {
                Console.WriteLine("Ainda não há vendas para mostrar no relatório.");
                return;
            }

            decimal faturamentoTotal = 0;
            int unidadesVendidas = 0;

            foreach (Venda venda in vendas)
            {
                faturamentoTotal += venda.CalcularTotal();
                unidadesVendidas += venda.Quantidade;
            }

            Console.WriteLine("Quantidade de vendas: " + vendas.Count);
            Console.WriteLine("Jogos vendidos: " + unidadesVendidas);
            Console.WriteLine("Faturamento total: " + faturamentoTotal.ToString("C2"));
        }

        static void SalvarDados()
        {
            try
            {
                DadosLoja dados = new DadosLoja();

                foreach (Jogo jogo in jogos)
                {
                    dados.Jogos.Add(new JogoSalvo
                    {
                        Id = jogo.Id,
                        Nome = jogo.Nome,
                        Preco = jogo.Preco,
                        QuantidadeEstoque = jogo.QuantidadeEstoque,
                        Plataforma = jogo.Plataforma,
                        Genero = jogo.Genero,
                        ClassificacaoIndicativa = jogo.ClassificacaoIndicativa
                    });
                }

                foreach (Cliente cliente in clientes)
                {
                    dados.Clientes.Add(new ClienteSalvo
                    {
                        Nome = cliente.Nome,
                        Email = cliente.Email,
                        Telefone = cliente.Telefone
                    });
                }

                foreach (Venda venda in vendas)
                {
                    dados.Vendas.Add(new VendaSalva
                    {
                        Id = venda.Id,
                        EmailCliente = venda.Cliente.Email,
                        IdJogo = venda.Jogo.Id,
                        Quantidade = venda.Quantidade,
                        DataVenda = venda.DataVenda
                    });
                }

                foreach (SolicitacaoJogo solicitacao in solicitacoes)
                {
                    dados.Solicitacoes.Add(new SolicitacaoSalva
                    {
                        Id = solicitacao.Id,
                        EmailCliente = solicitacao.Cliente.Email,
                        NomeJogo = solicitacao.NomeJogo,
                        Plataforma = solicitacao.Plataforma,
                        DataSolicitacao = solicitacao.DataSolicitacao
                    });
                }

                ArmazenamentoJson.Salvar("dados_gamestore.json", dados);
                Console.WriteLine("Dados salvos com sucesso!");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro ao salvar os dados: " + erro.Message);
            }
        }

        static void CarregarDados()
        {
            try
            {
                string caminho = "dados_gamestore.json";

                if (!File.Exists(caminho))
                {
                    Console.WriteLine("Ainda não existe um arquivo de dados salvo.");
                    return;
                }

                DadosLoja dados = ArmazenamentoJson.Carregar<DadosLoja>(caminho);

                jogos.Clear();
                clientes.Clear();
                vendas.Clear();
                solicitacoes.Clear();

                foreach (ClienteSalvo clienteSalvo in dados.Clientes)
                {
                    clientes.Add(new Cliente(
                        clienteSalvo.Nome,
                        clienteSalvo.Email,
                        clienteSalvo.Telefone
                    ));
                }

                foreach (JogoSalvo jogoSalvo in dados.Jogos)
                {
                    Jogo jogo = new Jogo(
                        jogoSalvo.Nome,
                        jogoSalvo.Preco,
                        jogoSalvo.QuantidadeEstoque,
                        jogoSalvo.Plataforma,
                        jogoSalvo.Genero,
                        jogoSalvo.ClassificacaoIndicativa
                    );

                    jogo.Id = jogoSalvo.Id;
                    Produto.AtualizarProximoId(jogo.Id);
                    jogos.Add(jogo);
                }

                foreach (VendaSalva vendaSalva in dados.Vendas)
                {
                    Cliente cliente = clientes.Find(c =>
                        string.Equals(c.Email, vendaSalva.EmailCliente,
                            StringComparison.OrdinalIgnoreCase));

                    Jogo jogo = jogos.Find(j => j.Id == vendaSalva.IdJogo);

                    if (cliente != null && jogo != null)
                    {
                        vendas.Add(Venda.Restaurar(
                            vendaSalva.Id,
                            cliente,
                            jogo,
                            vendaSalva.Quantidade,
                            vendaSalva.DataVenda
                        ));
                    }
                }

                foreach (SolicitacaoSalva solicitacaoSalva in dados.Solicitacoes)
                {
                    Cliente cliente = clientes.Find(c =>
                        string.Equals(c.Email, solicitacaoSalva.EmailCliente,
                            StringComparison.OrdinalIgnoreCase));

                    if (cliente != null)
                    {
                        solicitacoes.Add(SolicitacaoJogo.Restaurar(
                            solicitacaoSalva.Id,
                            cliente,
                            solicitacaoSalva.NomeJogo,
                            solicitacaoSalva.Plataforma,
                            solicitacaoSalva.DataSolicitacao
                        ));
                    }
                }

                Console.WriteLine("Dados carregados com sucesso!");
                Console.WriteLine("Jogos: " + jogos.Count);
                Console.WriteLine("Clientes: " + clientes.Count);
                Console.WriteLine("Vendas: " + vendas.Count);
                Console.WriteLine("Pedidos: " + solicitacoes.Count);
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro ao carregar os dados: " + erro.Message);
            }
        }

        static void Aguardar()
        {
            Console.WriteLine("\nAperte uma tecla para continuar...");
            Console.ReadKey();
        }
    }
}
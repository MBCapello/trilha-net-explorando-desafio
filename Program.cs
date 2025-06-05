using System.Globalization;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Suite> suites = new List<Suite>
{
    new Suite("Standard", 2, 100),
    new Suite("Premium", 4, 180),
    new Suite("Master", 6, 250)
};

Reserva reserva = null;
DateTime dataEntrada = DateTime.MinValue;

while (true)
{
    Console.Clear();
    Console.WriteLine(@" 
╔══════════════════════════════════════════════════════════════╗
║   🏨 RESERVA FÁCIL - Sistema de Reservas de Hotel DIO 🗝️   ║
╚══════════════════════════════════════════════════════════════╝
");
    Console.WriteLine("Bem-vindo ao sistema de reservas de hospedagem!");
    Console.WriteLine("1 - Cadastrar Suites");
    Console.WriteLine("2 - Exibir Suites");
    Console.WriteLine("3 - Realizar reserva");
    Console.WriteLine("4 - Exibir informações da reserva");
    Console.WriteLine("5 - Sair");
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();

    if (opcao == "1")
    {
        Console.WriteLine("\n--- CADASTRO DE SUÍTES ---");
        Console.Write("Digite o tipo da suíte: ");
        String TipoSuite = Console.ReadLine();
        Console.Write("Digite a capacidade da suíte: ");
        int CapacidadeSuite;
        while (!int.TryParse(Console.ReadLine(), out CapacidadeSuite) || CapacidadeSuite <= 0)
        {
            Console.WriteLine("Capacidade inválida. Digite um número maior que zero.");
            Console.Write("Digite a capacidade da suíte: ");
        }
        Console.Write("Digite o valor da diária: ");
        decimal ValorDiaria;
        while (!decimal.TryParse(Console.ReadLine(), out ValorDiaria) || ValorDiaria <= 0)
        {
            Console.WriteLine("Valor inválido. Digite um número maior que zero.");
            Console.Write("Digite o valor da diária: ");
        }

        suites.Add(new Suite(TipoSuite, CapacidadeSuite, ValorDiaria));
        Console.WriteLine("Suíte cadastrada com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
    else if (opcao == "2")
    {
        Console.WriteLine("\n--- LISTA DE SUÍTES ---");
        if (suites.Count == 0)
        {
            Console.WriteLine("Nenhuma suíte cadastrada.");
        }
        else
        {
            foreach (var suite in suites)
            {
                Console.WriteLine($"Tipo: {suite.TipoSuite}, Capacidade: {suite.Capacidade}, Valor diária: {suite.ValorDiaria.ToString("C")}");
            }
        }
        Console.ReadKey();
    }
    else if (opcao == "3")
    {
        // Cadastro de hóspedes
        Console.Write("Quantos hóspedes deseja cadastrar? ");
        if (!int.TryParse(Console.ReadLine(), out int qtdHospedes) || qtdHospedes <= 0)
        {
            Console.WriteLine("Quantidade inválida. Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            continue;
        }

        List<Pessoa> hospedes = new List<Pessoa>();
        for (int i = 1; i <= qtdHospedes; i++)
        {
            while (true)
            {
                Console.Write($"Digite o nome completo do hóspede {i} (nome e sobrenome): ");
                string nomeCompleto = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(nomeCompleto)) continue;

                var partes = nomeCompleto.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
                if (partes.Length < 2)
                {
                    Console.WriteLine("Por favor, informe nome e sobrenome.");
                    continue;
                }
                try
                {
                    hospedes.Add(new Pessoa(partes[0], partes[1]));
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

        // Seleção de suíte compatível
        var suitesDisponiveis = suites.Where(s => s.Capacidade >= qtdHospedes).ToList();
        if (suitesDisponiveis.Count == 0)
        {
            Console.WriteLine("Não há suítes disponíveis para essa quantidade de hóspedes.");
            Console.ReadKey();
            continue;
        }

        Console.WriteLine("\nSuítes disponíveis:");
        for (int i = 0; i < suitesDisponiveis.Count; i++)
        {
            var s = suitesDisponiveis[i];
            Console.WriteLine($"{i + 1} - {s.TipoSuite} (Capacidade: {s.Capacidade}, Valor diária: {s.ValorDiaria.ToString("C")})");
        }
        int escolhaSuite;
        while (true)
        {
            Console.Write("Escolha o número da suíte desejada: ");
            if (int.TryParse(Console.ReadLine(), out escolhaSuite) &&
                escolhaSuite > 0 && escolhaSuite <= suitesDisponiveis.Count)
                break;
            Console.WriteLine("Opção inválida.");
        }
        Suite suiteEscolhida = suitesDisponiveis[escolhaSuite - 1];

        // Dias de estadia
        int diasReservados;
        while (true)
        {
            Console.Write("Quantos dias de estadia? ");
            if (int.TryParse(Console.ReadLine(), out diasReservados) && diasReservados > 0)
                break;
            Console.WriteLine("Número de dias inválido.");
        }

        // Data de entrada (não pode ser hoje)
        while (true)
        {
            Console.Write("Data de entrada (formato dd/MM/yyyy, não pode ser hoje): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataEntrada)
                && dataEntrada.Date > DateTime.Now.Date)
                break;
            Console.WriteLine("Data inválida. A reserva não pode ser para hoje ou para o passado.");
        }

        // Criação da reserva
        reserva = new Reserva(diasReservados)
        {
            Suite = suiteEscolhida,
            Hospedes = hospedes
        };

        // Resumo
        Console.WriteLine("\n--- RESUMO DA RESERVA ---");
        Console.WriteLine($"Data de entrada: {dataEntrada:dd/MM/yyyy}");
        Console.WriteLine($"Dias reservados: {diasReservados}");
        Console.WriteLine($"Suíte: {suiteEscolhida.TipoSuite} (Capacidade: {suiteEscolhida.Capacidade})");
        Console.WriteLine($"Valor diária: {suiteEscolhida.ValorDiaria.ToString("C")}");
        Console.WriteLine($"Hóspedes:");
        foreach (var h in hospedes)
            Console.WriteLine($"- {h.NomeCompleto}");
        Console.WriteLine($"Valor total: {reserva.CalcularValorDiaria().ToString("C")}");
        Console.WriteLine("-------------------------");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
    else if (opcao == "4")
    {
        if (reserva == null)
        {
            Console.WriteLine("Nenhuma reserva realizada ainda.");
        }
        else
        {
            Console.WriteLine("\n--- INFORMAÇÕES DA RESERVA ---");
            Console.WriteLine("==============================");
            Console.WriteLine($"Data de entrada: {dataEntrada:dd/MM/yyyy}");
            Console.WriteLine($"Suíte: {reserva.Suite.TipoSuite}");
            Console.WriteLine($"Capacidade: {reserva.Suite.Capacidade}");
            Console.WriteLine($"Valor diária: {reserva.Suite.ValorDiaria.ToString("C")}");
            Console.WriteLine($"Dias reservados: {reserva.DiasReservados}");
            Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine("Hóspedes:");
            foreach (var h in reserva.Hospedes)
                Console.WriteLine($"- {h.NomeCompleto}");
            Console.WriteLine($"Valor total: {reserva.CalcularValorDiaria().ToString("C")}");
            Console.WriteLine("==============================");
        }
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
    else if (opcao == "5")
    {
        Console.WriteLine("Saindo...");
        break;
    }
    else
    {
        Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
        Console.ReadKey();
    }
}
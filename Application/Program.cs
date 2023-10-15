using Interfaces;
using Models;

string menu =
            "1 - Reservar suite \n" +
            "2 - Nova Suite \n" +
            "3 - Listar Reservas \n" +
            "4 - Encerrar";

List<Suite> suitesDisponiveis = new();
List<Reserva> reservasDoHotel = new();

bool loop = true;

while (loop)
{   
    OnKeyPress();
    Console.WriteLine(menu);
    int escolha = Convert.ToInt32(Console.ReadLine());
    switch (escolha)
    {
        case 1:
            NovaReserva();
            break;
        case 2:
            NovaSuite();
            break;
        case 3:
            ListarReservas();
            break;
        case 4:
            loop = false;
            break;
        default:
            continue;
    }
}

void OnKeyPress()
{
    Console.WriteLine("Pressione a tecla enter para continuar ...");
    while (true)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            break;
        }
    }
}

void ListarReservas()
{
    if (reservasDoHotel.Count > 0)
    {
        for (int i = 0; i < reservasDoHotel.Count; i++)
        {
            Reserva reserva = reservasDoHotel[i];
            Console.WriteLine("Hospedes: ");
            for (int j = 0; j < reserva.Hospedes.Count; j++)
            {
                Console.WriteLine($"Hospede Nº {j + 1} {reserva.Hospedes[j]}");
            }
            Console.WriteLine($"Suite: {reserva.Suite.TipoSuite}");
            Console.WriteLine($"Quantidade de hospedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Dias na suite: {reserva.DiasReservados}");
            Console.WriteLine($"Valor total: {reserva.CalcularValorDiaria()}");

        }
    }
    else
    {
        Console.WriteLine("Não existem reservas !");
    }
}


void NovaSuite()
{
    Console.WriteLine("Qual o tipo da suite?");
    string? tipoSuite = Console.ReadLine();
    Console.WriteLine("Qual a capacidade ?");
    int CapacidadeDeHospedes = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Qual o valor por dia ?: Exemplo 20,00");
    decimal valorDiariaSuite = Convert.ToDecimal(Console.ReadLine());
    Suite suite = new(tipoSuite, CapacidadeDeHospedes, valorDiariaSuite);
    suitesDisponiveis.Add(suite);
    Console.WriteLine("Suite adicionada com sucesso !");
}


void NovaReserva()
{
    List<Pessoa> hospedes = new();
    Console.WriteLine("Quantas pessoas utilizarão a suite?");
    int quantidadeHospedes = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Quantas Dias ficarão na suite?");
    int quantidadeDiasNaSuite = Convert.ToInt32(Console.ReadLine());
    if (quantidadeHospedes > 0)
    {
        for (int count = 0; count < quantidadeHospedes; count++)
        {
            Console.WriteLine($"Digite o nome do hospede Nº{count + 1}: ");
            string? nome = Console.ReadLine();
            Console.WriteLine($"Digite o sobrenome do hospede Nº{count + 1}: ");
            string? sobrenome = Console.ReadLine();
            Pessoa pessoa = new(nome: nome, sobrenome: sobrenome);
            hospedes.Add(pessoa);
        }
        Suite? suiteDisponivel = suitesDisponiveis.Find(
                                            suite
                                            => suite.Capacidade
                                            >= quantidadeHospedes);
        if (suiteDisponivel != null)
        {
            IReserva<List<Pessoa>, Suite> reserva = new Reserva(quantidadeDiasNaSuite);
            reserva.CadastrarSuite(suiteDisponivel);
            reserva.CadastrarHospedes(hospedes);
            reservasDoHotel.Add((Reserva)reserva);
            Console.WriteLine("Reserva criada !");
        }
        else
        {
            Console.WriteLine("Não foi possível encontrar " +
                                "Uma suite disponível !");
        }
    }
    else
    {
        Console.WriteLine("Quantidade de hospedes inválidos !");
    }
}
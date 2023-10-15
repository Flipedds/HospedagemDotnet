using Interfaces;
using Models;

string menu =
            "1 - Reservar suite \n" +
            "2 - Nova Suite \n" +
            "3 - Encerrar";

List<Suite> suitesDisponiveis = new();
List<Reserva> reservasDoHotel = new();

bool loop = true;

while (loop)
{
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
            loop = false;
            break;
        default:
            continue;
    }
}

void NovaSuite()
{
    Console.WriteLine("Qual o tipo da suite?");
    string? tipoSuite = Console.ReadLine();
    Console.WriteLine("Qual a capacidade ?");
    int CapacidadeDeHospedes = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Qual o valor por dia ?");
    decimal valorDiariaSuite = Convert.ToDecimal(Console.ReadLine());
    Suite suite = new(tipoSuite, CapacidadeDeHospedes, valorDiariaSuite);
    suitesDisponiveis.Add(suite);
    Console.WriteLine("Suite adicionada com sucesso !");
}

void NovaReserva()
{
    Console.WriteLine("Quantas pessoas utilizarão a suite?");
    List<Pessoa> hospedes = new();
    int quantidadeHospedes = Convert.ToInt32(Console.ReadLine());
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
            IReserva<List<Pessoa>, Suite> reserva = new Reserva(quantidadeHospedes);
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
using Interfaces;
namespace Models;

public class Hotel : IHotel
{
    private readonly List<Suite> SuitesDisponiveis;
    private readonly List<Reserva> ReservasDoHotel;

    public Hotel()
    {
        SuitesDisponiveis = new();
        ReservasDoHotel = new();
    }


    public void ListarReservas()
    {
        if (ReservasDoHotel.Count > 0)
        {
            for (int i = 0; i < ReservasDoHotel.Count; i++)
            {
                Reserva reserva = ReservasDoHotel[i];
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


    public void NovaSuite()
    {
        Console.WriteLine("Qual o tipo da suite?");
        string tipoSuite = Console.ReadLine();
        Console.WriteLine("Qual a capacidade ?");
        int CapacidadeDeHospedes = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Qual o valor por dia ?: Exemplo 20,00");
        decimal valorDiariaSuite = Convert.ToDecimal(Console.ReadLine());
        Suite suite = new(tipoSuite, CapacidadeDeHospedes, valorDiariaSuite);
        SuitesDisponiveis.Add(suite);
        Console.WriteLine("Suite adicionada com sucesso !");
    }


    public void NovaReserva()
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
                string nome = Console.ReadLine();
                Console.WriteLine($"Digite o sobrenome do hospede Nº{count + 1}: ");
                string sobrenome = Console.ReadLine();
                Pessoa pessoa = new(nome: nome, sobrenome: sobrenome);
                hospedes.Add(pessoa);
            }
            Suite suiteDisponivel = SuitesDisponiveis.Find(
                                                suite
                                                => suite.Capacidade
                                                >= quantidadeHospedes);
            if (suiteDisponivel != null)
            {
                IReserva<List<Pessoa>, Suite> reserva = new Reserva(quantidadeDiasNaSuite);
                reserva.CadastrarSuite(suiteDisponivel);
                reserva.CadastrarHospedes(hospedes);
                ReservasDoHotel.Add((Reserva)reserva);
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


}

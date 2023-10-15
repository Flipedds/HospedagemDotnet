using Interfaces;

namespace Models;

public class Reserva : IReserva<List<Pessoa>, Suite>
{
    public List<Pessoa> Hospedes { get; set; }
    public Suite Suite { get; set; }

    private int _diasReservados;
    public int DiasReservados
    {
        get => _diasReservados;
        set => _diasReservados = value > 0 ? _diasReservados = value :
        throw
        new ArgumentException("Dias de reserva deve ser maior que 0 !");
    }

    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (hospedes.Count <= 0 || Suite.Capacidade < hospedes.Count)
        {
            throw new ArgumentException("Não é possível adicionar uma " +
                                        "lista de hospedes vazia ou maior que a capacidade!");
        }
        Hospedes = hospedes;
        Console.WriteLine("Hospedes adicionados a reserva !");
    }
    public void CadastrarSuite(Suite suite) => Suite = suite;

    public int ObterQuantidadeHospedes() => Hospedes.Count;

    public decimal CalcularValorDiaria()
    {
        decimal valorTotal = DiasReservados * Suite.ValorDiaria;
        if (DiasReservados > 10)
        {
            decimal valorDesconto = (valorTotal * 10) / 100;
            return valorTotal - valorDesconto;

        }
        return valorTotal;
    }
}

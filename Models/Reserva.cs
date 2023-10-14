using Interfaces;

namespace Models;

public class Reserva : IReserva<List<Pessoa>, Suite>
{
    public List<Pessoa> Hospedes { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

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

    public decimal CalcularValorDiaria() => (decimal) DiasReservados * Suite.ValorDiaria;
}

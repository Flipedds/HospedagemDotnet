namespace Interfaces;

public interface IReserva<T, U>
{
    T Hospedes {get; set;}
    U Suite {get; set;}

    int DiasReservados {get; set;}

    void CadastrarHospedes(T hospedes);
    void CadastrarSuite(U suite);

    int ObterQuantidadeHospedes();

    decimal CalcularValorDiaria();
}

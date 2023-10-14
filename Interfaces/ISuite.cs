namespace Interfaces;

public interface ISuite
{
    string TipoSuite { get; set; }
    int Capacidade { get; set; }

    decimal ValorDiaria { get; set; }
}

using Interfaces;

namespace Models;

public class Suite : ISuite
{

    private string _tipoSuite;
    private int _capacidade;
    private decimal _valorDiaria;
    public string TipoSuite
    {
        get => _tipoSuite;
        set => _tipoSuite = value != "" ? _tipoSuite = value 
        : throw new ArgumentException("O tipo da suite não pode ser vazio!");
    }
    public int Capacidade
    {
        get => _capacidade;
        set => _capacidade = value > 0 ? _capacidade = value 
        : throw new ArgumentException("A capacidade não pode ser 0!");
    }

    public decimal ValorDiaria
    {
        get => _valorDiaria;
        set => _valorDiaria = value > 0 ? _valorDiaria = value 
        : throw new ArgumentException("O valor da diária não pode ser 0 ou menos!");
    }


    public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
    {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }
}

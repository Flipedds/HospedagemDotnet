using Interfaces;

namespace Models;

public class Pessoa : IPessoa
{

    private string _nome;
    private string _sobrenome;

    public string Nome
    {
        get => _nome;
        set => _nome = value != "" ? _nome = value : throw new ArgumentException("O nome não pode ser vazio!");
    }
    public string Sobrenome
    {
        get => _sobrenome;
        set =>  _sobrenome = value != "" ? _sobrenome = value : throw new ArgumentException("O sobrenome não pode ser vazio!");
    }

    public Pessoa(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Sobrenome: {Sobrenome}";
    }
}

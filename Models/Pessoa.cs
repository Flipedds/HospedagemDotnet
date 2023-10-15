using Interfaces;

namespace Models;

public class Pessoa: IPessoa
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

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

using Interfaces;
using Models;

// Pessoa pessoa = new("Filipe", "Silva");
// Pessoa pessoaDois = new("Pedro", "Silva");
// Pessoa pessoaTres = new("João", "Silva");
// Pessoa pessoaQuatro = new("Maria", "Silva");
// List<Pessoa> familia  = new(){pessoa, pessoaDois, pessoaTres, pessoaQuatro};
// Suite suite = new("familia", 4, 50.20M);

// IReserva<List<Pessoa>, Suite> reservaFamilia = new Reserva(12);
// reservaFamilia.CadastrarSuite(suite);
// reservaFamilia.CadastrarHospedes(familia);

// Console.WriteLine(reservaFamilia.ObterQuantidadeHospedes());
// Console.WriteLine(reservaFamilia.CalcularValorDiaria());

string menu =
            "1 - Reservar suite \n" +
            "2 - Nova Suite \n" +
            "3 - Encerrar";

bool loop = true;

while (loop)
{
    Console.WriteLine(menu);
    int escolha = Convert.ToInt32(Console.ReadLine());
    switch (escolha)
    {
        case 1:
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
                foreach (var hospede in hospedes)
                {
                    Console.WriteLine(hospede.ToString());
                }
            }
            break;

        default:
            continue;
    }
}

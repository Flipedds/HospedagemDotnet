using Interfaces;
using Models;

Pessoa pessoa = new("Filipe", "Silva");
Pessoa pessoaDois = new("Pedro", "Silva");
Pessoa pessoaTres = new("João", "Silva");
Pessoa pessoaQuatro = new("Maria", "Silva");
List<Pessoa> familia  = new(){pessoa, pessoaDois, pessoaTres, pessoaQuatro};
Suite suite = new("familia", 4, 50.20M);

IReserva<List<Pessoa>, Suite> reservaFamilia = new Reserva(10);
reservaFamilia.CadastrarSuite(suite);
reservaFamilia.CadastrarHospedes(familia);

Console.WriteLine(reservaFamilia.ObterQuantidadeHospedes());
Console.WriteLine(reservaFamilia.CalcularValorDiaria());

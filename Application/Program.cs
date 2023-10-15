using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;

string menu =
            "1 - Reservar suite \n" +
            "2 - Nova Suite \n" +
            "3 - Listar Reservas \n" +
            "4 - Encerrar";

var serviceProvider = new ServiceCollection()
    .AddSingleton<IHotel, Hotel>()
    .BuildServiceProvider();

var hotel = serviceProvider.GetRequiredService<IHotel>();

bool loop = true;

while (loop)
{   
    OnKeyPress();
    Console.WriteLine(menu);
    int escolha = Convert.ToInt32(Console.ReadLine());
    switch (escolha)
    {
        case 1:
            hotel.NovaReserva();
            break;
        case 2:
            hotel.NovaSuite();
            break;
        case 3:
            hotel.ListarReservas();
            break;
        case 4:
            loop = false;
            break;
        default:
            continue;
    }
}

static void OnKeyPress()
{
    Console.WriteLine("Pressione a tecla enter para continuar ...");
    while (true)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            break;
        }
    }
}
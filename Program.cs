using EstacionamentoApp.Models;

class Program
{
    static void Main()
    {
        Estacionamento est = new Estacionamento(10.0m, 8.0m);
        est.ExibirMenu();
    }
}

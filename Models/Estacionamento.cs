using System;
using System.Collections.Generic;
using System.Linq;

namespace EstacionamentoApp.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void ExibirMenu()
        {
            while (true)
            {
                Console.Clear();
                ExibirCabecalho();

                Console.SetCursorPosition(0, 6);
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Adicionar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");

                Console.Write("\nOpção: ");
                string? opcao = Console.ReadLine();

                Console.SetCursorPosition(0, 14);
                Console.WriteLine(new string('-', 50));

                switch (opcao)
                {
                    case "1":
                        AdicionarVeiculo();
                        break;
                    case "2":
                        RemoverVeiculo();
                        break;
                    case "3":
                        ListarVeiculos();
                        break;
                    case "4":
                        Console.WriteLine("Encerrando o programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void ExibirCabecalho()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Banzatto Tecnologia");
            Console.WriteLine("Sistema de Controle de Estacionamento");
            Console.WriteLine("--------------------------------------");
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo: ");
            string? placa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa.ToUpper());
                Console.WriteLine($"Veículo {placa.ToUpper()} adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Placa inválida.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            string? placa = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida.");
                return;
            }

            placa = placa.ToUpper();

            if (veiculos.Any(v => v == placa))
            {
                Console.Write("Digite o número de horas estacionado: ");
                string? inputHoras = Console.ReadLine();

                if (int.TryParse(inputHoras, out int horas))
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido. Valor cobrado: R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Horas inválidas.");
                }
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Veículos estacionados:");
                foreach (var v in veiculos)
                {
                    Console.WriteLine($"- {v}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum veículo estacionado.");
            }
        }
    }
}

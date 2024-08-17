using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar (Ex.: ABC-1234 ou ABC-1A34):");
            string placa = Console.ReadLine();

            if (VerificaPlaca(placa))
            {
                if (!veiculos.Any(x => x.ToUpper() == placa.ToUpper())) 
                    veiculos.Add(placa);
                else 
                    Console.WriteLine("Opa! Esse veículo já está estacionado aqui.");
            }
        }

        public void RemoverVeiculo()
        {
            string placa = "";
            
            Console.WriteLine("Digite a placa do veículo para remover (Ex.: ABC-1234 ou ABC-1A34):");
            placa = Console.ReadLine();

            if (VerificaPlaca(placa))
            {
                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    int horas = 0;
                    decimal valorTotal = 0; 

                    horas = Convert.ToInt32(Console.ReadLine());
                    valorTotal = precoInicial + (precoPorHora * horas);

                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string placa in veiculos)
                    Console.WriteLine(placa);
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool VerificaPlaca(string placa)
        {
            string regex = "^[A-Z]{3}-[0-9][A-Z0-9][0-9]{2}$";
            if (!Regex.IsMatch(placa, regex))
            {
                Console.WriteLine("\n> Placa Inválida!\n");
                return false;
            }

            return true;
        }
    }
}

using System;
using System.Text.RegularExpressions;


//Heurística 5 - Prevenção de Erros:
//Confirmação antes de ações perigosas (formatar).

//Heurística 6 - Reconhecimento:
//Menu de opções visível para o usuário.

//Heurística 10 - Ajuda:
//Comando help disponível a qualquer momento.


class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== TERMINAL DE SUPORTE ===");
            Console.WriteLine("1 - Pingar IP");
            Console.WriteLine("2 - Formatar Unidade");
            Console.WriteLine("Digite 'help' para ajuda");
            Console.Write("Escolha: ");

            string comando = Console.ReadLine().ToLower();

            // HELP
            if (comando == "help" || comando == "?")
            {
                Console.WriteLine("\n=== AJUDA ===");
                Console.WriteLine("1 - Pingar IP: testa conexão");
                Console.WriteLine("2 - Formatar Unidade: apaga tudo");
                Console.WriteLine("help ou ?: mostra ajuda\n");
                continue;
            }

            // PING
            if (comando == "1")
            {
                Console.Write("Digite o IP: ");
                string ip = Console.ReadLine();

                if (!Regex.IsMatch(ip, @"^\d{1,3}(\.\d{1,3}){3}$"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("IP inválido! Use somente numeros e pontos ex: 123.456.789.10");
                    Console.ResetColor();
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ping realizado com sucesso!");
                Console.ResetColor();
            }

            // FORMATAR
            else if (comando == "2")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠️ ATENÇÃO: Isso apagará tudo!");
                Console.ResetColor();

                Console.Write("Tem certeza? (sim/nao): ");
                string confirmacao = Console.ReadLine().ToLower();

                if (confirmacao == "sim")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unidade formatada!");
                    Console.ResetColor();
                }
                else if (confirmacao == "nao")
                {
                    Console.WriteLine("Operação cancelada.");
                }
                else
                {
                    Console.WriteLine("Digite apenas 'sim' ou 'nao'.");
                }
            }

            else
            {
                Console.WriteLine("Comando inválido. Digite 'help'.");
            }
        }
    }
}
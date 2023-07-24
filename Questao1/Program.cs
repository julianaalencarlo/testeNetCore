using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Questao01
{
    public class ContaBancaria
    {
        int numero;
        String titular;
        double saldo;

        public ContaBancaria(int numero, String titular, double saldo)
        {
            this.numero = numero;
            this.titular = titular;
            this.saldo = saldo;
        }

        public int getNumero()
        {
            return numero;
        }

        public String getTitular()
        {
            return titular;
        }

        public double getSaldo()
        {
            return saldo;
        }

        public void setNumero(int novoNumero)
        {
            numero = novoNumero;
        }

        public void setSaldo(double novoSaldo)
        {
            saldo = novoSaldo;
        }

        public static void Main(String[] args)
        {
            List<ContaBancaria> contasBancarias = new List<ContaBancaria>();
            {
                contasBancarias.Add(new ContaBancaria(2222, "Juliana", 40.50));
                contasBancarias.Add(new ContaBancaria(5555, "Janine", 200));
                contasBancarias.Add(new ContaBancaria(3333, "Luis", 100));
            }

            void printOpcoes()
            {
                Console.WriteLine("Por favor escolha entre as opções abaixo...");
                Console.WriteLine("1. Deposito");
                Console.WriteLine("2. Saque");
                Console.WriteLine("3. Extrato");
                Console.WriteLine("4. Sair");
                Console.WriteLine("-----------------------------------------------");
            }

            void deposito(ContaBancaria conta)
            {
                Console.WriteLine("Entre um valor para depósito:");
                double deposito = Double.Parse(Console.ReadLine());
                conta.setSaldo(conta.saldo + deposito);
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Dados da conta atualizados: ");
            }

            void saque(ContaBancaria conta)
            {
                Console.WriteLine("Entre um valor para saque:");
                double saque = Double.Parse(Console.ReadLine());
                conta.setSaldo(conta.saldo - saque - 3.5);
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Dados da conta atualizados: ");
            }

            void saldo(ContaBancaria conta)
            {
                Console.WriteLine("Saldo atual é de R$ " + conta.getSaldo());
            }

            void dadosConta(ContaBancaria conta)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Conta " + (conta.getNumero()));
                Console.WriteLine("Titular: " + conta.getTitular());
                Console.WriteLine("Saldo: " + conta.getSaldo());
                Console.WriteLine("-----------------------------------------------");
                // Conta 5447, Titular: Milton Gonçalves, Saldo: $ 550.00
            }

            void criarConta()
            {
                Console.Write("Por favor informe seus dados: ");
                Console.Write("Entre o número da conta: ");
                int numero = int.Parse(Console.ReadLine());
                Console.Write("Entre o titular da conta: ");
                string titular = Console.ReadLine();
                Console.Write("Haverá depósito inicial (s/n)? ");
                char resp = char.Parse(Console.ReadLine());
                if (resp == 's' || resp == 'S')
                {
                    Console.Write("Entre o valor de depósito inicial: ");
                    double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    contasBancarias.Add(new ContaBancaria(numero, titular, depositoInicial));
                }
                else
                {
                    contasBancarias.Add(new ContaBancaria(numero, titular, 0));
                }
            }

            void menuConta(ContaBancaria conta)
            {
                int opcao = 0;
                do
                {
                    try
                    {
                        printOpcoes();
                        opcao = int.Parse(Console.ReadLine());
                    }
                    catch { }

                    if (opcao == 1) { deposito(conta); dadosConta(conta); }
                    else if (opcao == 2) { saque(conta); dadosConta(conta); }
                    else if (opcao == 3) { saldo(conta); }
                    else if (opcao == 4) { break; }
                    else { opcao = 0; }
                }
                while (opcao != 4);
                Console.WriteLine("Obrigado e volte sempre.");
                Console.WriteLine("-----------------------------------------------");
            }

            //Começando
            Console.WriteLine("Bem vindo, deseja criar uma nova conta? (s/n)");
            char resposta = char.Parse(Console.ReadLine());
            ContaBancaria conta;
            if (resposta == 's' || resposta == 'S')
            {
                criarConta();
                conta = contasBancarias.LastOrDefault();
                dadosConta(conta);
                menuConta(conta);
            }
            else
            {
                Console.Write("Por favor informe o número da sua conta bancária.");
                int numeroAtual = 0;
                ContaBancaria contaInformada;

                try
                {
                    numeroAtual = int.Parse(Console.ReadLine());
                    contaInformada = contasBancarias.FirstOrDefault(a => a.numero == numeroAtual);
                    if (contaInformada != null)
                    {
                        conta = contasBancarias.LastOrDefault(a => a.numero == numeroAtual);
                        Console.WriteLine("Bem vindo(a) " + conta.getTitular());
                        menuConta(conta);
                    }
                    else
                    {
                        Console.WriteLine("Conta bancária não encontrada, por favor digite novamente.");
                    }
                }
                catch
                {
                    Console.WriteLine("Conta bancária não encontrada, por favor digite novamente.");
                }
            }


        }

    }

}

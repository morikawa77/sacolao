using System;
using System.Globalization;

namespace sacolao
{
    class MainClass
    {
        // seta variáveis globais
        static char escolha = 's';
        static decimal subtotal;

        public static void Main(string[] args)
        {
            // loop do pedido
            do
            {
                escolhaFruta();

            } while (escolha == 's');

            // fecha a conta ao sair do loop
            fechaConta();

            Console.WriteLine("");
        }

        static void escolhaFruta()
        {
            int idFruta = 0;
            int qtdFruta = 0;
            decimal valorFruta = 0;

            Console.WriteLine("Tabela de Preços \n\n");
            Console.WriteLine("Código      -           Fruta           -           Valor\n");
            Console.WriteLine("1           -           Tomate          -           R$ 4,99");
            Console.WriteLine("2           -           Melão           -           R$ 2,36");
            Console.WriteLine("3           -           Abacaxi         -           R$ 3,99");
            Console.WriteLine("4           -           Manga           -           R$ 4,85\n\n");

            bool Result = false;

            while (!Result)
            {
                Console.Write("Digite o código da fruta: ");
                Result = int.TryParse(Console.ReadLine(), out idFruta);
            }

            bool Result2 = false;
            while (!Result2)
            {
                Console.Write("Digite a quantidade da fruta: ");
                Result2 = int.TryParse(Console.ReadLine(), out qtdFruta);
            }

            /*
             1 - Tomate - R$ 4,99
             2 - Melão - R$ 2,36
             3 - Abacaxi - R$ 3,99
             4 - Manga - R$ 4,85
             */

            switch (idFruta)
            {
                case 1:
                    valorFruta = 4.99m;
                    break;
                case 2:
                    valorFruta = 2.369m;
                    break;
                case 3:
                    valorFruta = 3.99m;
                    break;
                case 4:
                    valorFruta = 4.85m;
                    break;
                default:
                    Console.WriteLine("Código inválido!");
                    break;
            }

            // Calcula subtotal
            subtotal = subtotal + (qtdFruta * valorFruta);

            // Prossegue o loop?
            Console.Write("Deseja inserir outro item? S ou N ?");
            escolha = Convert.ToChar(Console.ReadLine().ToLower());
            Console.WriteLine("");
        }

        static void fechaConta()
        {
            int formaPagamento = 0;
            decimal total = 0;

            bool Result3 = false;
            bool Result4 = false;

            while (!Result3)
            {
                Console.Write("Qual a forma de pagamento? 1 - À Vista  |  2 - A Prazo ");
                Result3 = int.TryParse(Console.ReadLine(), out formaPagamento);
            }


            /*
            A vista 5% de desconto
            A prazo 10% de juros           
            */

            if (formaPagamento == 1)
            {
                total = subtotal * 0.95m;
                Result4 = true;
            }
            else if (formaPagamento == 2)
            {
                total = subtotal * 1.1m;
                Result4 = true;
            }
            else
            {
                Console.WriteLine("Forma de pagamento inválida, tente novamente...");
                Result4 = false;
                fechaConta();
            }

            if (Result4)
            {
                Console.Write($"O valor total é {total.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}");
            }
        }

    }
}

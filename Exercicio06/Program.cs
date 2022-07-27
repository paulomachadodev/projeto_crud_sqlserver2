using Exercicio06.Controllers;
using Exercicio06.Repositories;

namespace Exercicio06
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var funcionarioController = new FuncionarioController();

            try
            {
                Console.WriteLine("\n *** ESCOLHA UMA OPÇÃO *** \n");

                Console.WriteLine("(1) Cadastrar Funcionário");
                Console.WriteLine("(2) Atualizar Funcionário");
                Console.WriteLine("(3) Deletar Funcionário");
                Console.WriteLine("(4) Consultar todos os funcionários\n");

                Console.Write("Informe o que deseja fazer........: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                    
                        funcionarioController.CadastrarFuncionario();

                        break;

                    case 2:

                        funcionarioController.AtualizarFuncionario();

                        break;

                    case 3:

                        funcionarioController.DeletarFuncionario();

                        break;

                    case 4:

                        funcionarioController.ConsultarFuncionario();

                        break;
                  
                    default:

                        Console.WriteLine("\nOpção inválida.");

                        break;
                }

                Console.Write("\nDeseja continuar? (S, N)..: ");
                var escolha = Console.ReadLine();

                    if (escolha == "S")
                    {
                        Console.Clear(); //limpar a tela do Console
                        Main(args); //recursividade
                    }
                    else
                    {
                        Console.WriteLine("\nFIM DO PROGRAMA!");
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nErro: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}

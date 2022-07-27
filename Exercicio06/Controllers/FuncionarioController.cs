using Dapper;
using Exercicio06.Configurations;
using Exercicio06.Entities;
using Exercicio06.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio06.Controllers
{
    public class FuncionarioController
    {
        public void CadastrarFuncionario()
        {
            try
            {
                Console.WriteLine("\n *** CADASTRO DE FUNCIONÁRIOS *** \n");

                var funcionario = new Funcionario();

                funcionario.IdFuncionario = Guid.NewGuid();
                funcionario.DataAdmissao = DateTime.Now;

                Console.Write("Entre com o nome do Funcionário.......: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("Entre com o CPF do Funcionário........: ");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("Entre com a matricula do Funcionário..: ");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("Entre com o salário do Funcionário....: ");
                funcionario.Salario = decimal.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Create(funcionario);

                Console.WriteLine("\nFUNCIONÁRIO CADASTRADO COM SUCESSO NO BANCO DE DADOS\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao cadastrar funcionário: {e.Message}");
            }
        }

        public void AtualizarFuncionario()
        {
            try
            {
                Console.WriteLine("\n *** ATUALIZAÇÃO DE FUNCIONÁRIO *** \n");

                Console.Write("Entre com o ID do funcionário..................: ");
                var idFuncionario = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(idFuncionario);

                //verificar o produto foi encontrado
                if (funcionario != null)
                {
                    Console.Write("Entre com o novo nome do Funcionário.......: ");
                    funcionario.Nome = Console.ReadLine();

                    Console.Write("Entre com o CPF do Funcionário.............: ");
                    funcionario.Cpf = Console.ReadLine();

                    Console.Write("Entre com a matricula do Funcionário.......: ");
                    funcionario.Matricula = Console.ReadLine();

                    Console.Write("Entre com o salário do Funcionário.........: ");
                    funcionario.Salario = decimal.Parse(Console.ReadLine());

                    funcionarioRepository.Update(funcionario);

                    Console.WriteLine("\nFUNCIONÁRIO ATUALIZADO COM SUCESSO NO BANCO DE DADOS!");
                }
                else
                {
                    Console.WriteLine("\nFuncionário não encontrado, verifique o ID informado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao atualizar funcionaário: { e.Message}");
            }
        }

        public void DeletarFuncionario()
        {
            try
            {
                Console.WriteLine("\n *** EXCLUSÃO DE FUNCIONÁRIO *** \n");

                Console.Write("Entre com o ID do Funcionário.........: ");
                var idFuncionario = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(idFuncionario);

                if (funcionario != null)
                {
                    funcionarioRepository.Delete(funcionario);

                    Console.WriteLine("\nFUNCIONÁRIO EXCLUÍDO COM SUCESSO NO BANCO DE DADOS!");
                }
                else
                {
                    Console.WriteLine("\nFuncionário não encontrado, verifique o ID informado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao excluir funcionário: { e.Message}");
            }
        }

        public void ConsultarFuncionario()
        {
            try
            {
                Console.WriteLine("\n *** CONSULTA DE FUNCIONÁRIOS *** \n");

                var funcionarioRepository = new FuncionarioRepository();
                var funcionarios = funcionarioRepository.GetAll();

                foreach (var item in funcionarios)
                {
                    Console.WriteLine($"Id do Funcionário.........: {item.IdFuncionario}");

                    Console.WriteLine($"Data de Admissão..........: {item.DataAdmissao}");

                    Console.WriteLine($"CPF do Funcionário........: {item.Cpf}");

                    Console.WriteLine($"Matrícula do Funcionário..: {item.Matricula}");

                    Console.WriteLine($"Salário do Funcionário....: {item.Salario}");

                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao consultar funcionário: { e.Message}");
            }
        }

        //public void GetById()
        //{
        //    try
        //    {
        //        Console.WriteLine("\n *** CONSULTA DE FUNCIONÁRIOS POR ID *** \n");

        //        Console.Write("Entre com o ID do Funcionário.........: ");
        //        var idFuncionario = Guid.Parse(Console.ReadLine());

        //        var funcionarioRepository = new FuncionarioRepository();
        //        var funcionario = funcionarioRepository.GetById(idFuncionario);

        //        foreach (var item in funcionario)
        //        {
        //            Console.WriteLine($"Id do Funcionário.........: {item.IdFuncionario}");

        //            Console.WriteLine($"Data de Admissão..........: {item.DataAdmissao}");

        //            Console.WriteLine($"CPF do Funcionário........: {item.Cpf}");

        //            Console.WriteLine($"Matrícula do Funcionário..: {item.Matricula}");

        //            Console.WriteLine($"Salário do Funcionário....: {item.Salario}");

        //            Console.WriteLine("...");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"\nFalha ao consultar funcionário: {e.Message}");
        //    }

        //}

    }

}

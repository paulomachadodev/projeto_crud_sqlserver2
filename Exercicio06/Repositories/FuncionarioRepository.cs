using Dapper;
using Exercicio06.Configurations;
using Exercicio06.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio06.Repositories
{
    public class FuncionarioRepository
    {
        public void Create(Funcionario funcionario)
        {
            var sql = @"
                INSERT INTO FUNCIONARIO(
                    IDFUNCIONARIO,
                    NOME,
                    CPF,
                    MATRICULA,
                    DATAADMISSAO,
                    SALARIO)
                VALUES(
                    @IdFuncionario,
                    @Nome,
                    @Cpf,
                    @Matricula,
                    @DataAdmissao,
                    @Salario)
            ";

            using (var connection = new SqlConnection
                (SqlConfiguration.GetConnectionString()))
                {
                    connection.Execute(sql, funcionario);  
                }
        }

        public void Update(Funcionario funcionario)
        {
            var sql = @"
                UPDATE FUNCIONARIO
                SET
                    NOME = @Nome,
                    CPF = @Cpf,
                    MATRICULA = @Matricula,
                    DATAADMISSAO = @DataAdmissao,
                    SALARIO = @Salario
                WHERE
                    IDFUNCIONARIO = @IdFuncionario

            ";

            using (var connection = new SqlConnection
                (SqlConfiguration.GetConnectionString()))
                {
                    connection.Execute(sql, funcionario);
                }
        }

        public void Delete(Funcionario funcionario)
        {
            var sql = @"
                DELETE FROM FUNCIONRIO
                WHERE IDFUNCIONARIO = @IdFuncionario
            ";

            using (var connection = new SqlConnection
                (SqlConfiguration.GetConnectionString()))
            {
                connection.Execute(sql, funcionario);
            }
        }

        public List<Funcionario> GetAll()
        {
            var sql = @"
                SELECT * FROM FUNCIONARIO
                ORDER BY NOME
            ";

            using (var connection = new SqlConnection
                (SqlConfiguration.GetConnectionString()))
            {
                return connection.Query<Funcionario>(sql).ToList();
            }
        }

        public Funcionario GetById(Guid IdFuncionario)
        {
            var sql = @"
                SELECT * FROM FUNCIONARIO
                WHERE IDFUNCIONARIO = @IdFuncionario
            ";

            using (var connection = new SqlConnection
                (SqlConfiguration.GetConnectionString()))
            {
                return connection.Query<Funcionario>
                (sql, new { IdFuncionario }).FirstOrDefault();
            }
        }
    }
}

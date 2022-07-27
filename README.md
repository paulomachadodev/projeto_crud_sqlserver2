# Projeto Cadastro de Funcionário 
# C# .NET Console Application / SqlServer CRUD com SqlServer e Dapper

## Requisitos necessários:

* VisualStudio 2022
* SqlServer

## Script do banco de dados:
É necessário criar um banco de dados no SqlServer e incluir a sua connectionstring no projeto. Segue o script da tabela de produtos:

```sql
	CREATE TABLE FUNCIONARIO(
		IDFUNCIONARIO		UNIQUEIDENTIFIER	NOT NULL,
		NOME			NVARCHAR(150)		NOT NULL,
		CPF			NVARCHAR(15)		NOT NULL,
		MATRICULA		NVARCHAR(15)		NOT NULL,
		DATAADMISSAO		DATETIME		NOT NULL,
		SALARIO			DECIMAL(18,2)		NOT NULL,
		PRIMARY KEY(IDFUNCIONARIO))
	GO
```

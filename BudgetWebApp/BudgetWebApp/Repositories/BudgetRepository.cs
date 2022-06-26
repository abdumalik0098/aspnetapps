using BudgetWebApp.Models;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace BudgetWebApp.Repositories
{
    public interface IBudgetRepository
    {
        List<Transaction> GetTransactions();
    }


    public class BudgetRepository:IBudgetRepository
    {
        private readonly IConfiguration _configuration;

        public BudgetRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Transaction> GetTransactions()
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString(" ")))
            {
                var query =
                    @"SELECT t.Id, t.Name, t.TransactionType, t.CategoryId,  t.Amount, t.Date, c.Name AS Category
                      FROM Transactions AS t
                      LEFT JOIN Category AS c
                      ON t.CategoryId = c.Id;";

                var allTransactions = connection.Query<Transaction>(query);

                return allTransactions.ToList();
            }
        }

    }
}

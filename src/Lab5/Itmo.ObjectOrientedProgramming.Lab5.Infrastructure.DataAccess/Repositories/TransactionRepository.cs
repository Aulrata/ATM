using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Transactions;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly string _connectionString;

    public TransactionRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Create(Transaction transaction)
    {
        if (transaction is null) return;
        const string sql = """ 
                           INSERT INTO atm."UserTransactions" ("UserId", "AccountId", "Money", "Operation")
                           VALUES (@userId, @accountId, @money, @operation)
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("userId", transaction.UserId);
        command.Parameters.AddWithValue("accountId", transaction.AccountId);
        command.Parameters.AddWithValue("money", transaction.Money);
        command.Parameters.AddWithValue("operation", transaction.Operations.ToString());
        using NpgsqlDataReader reader = command.ExecuteReader();
    }

    public IEnumerable<Transaction> GetAllTransactionsByUser(int id)
    {
        const string sql = """
                           SELECT *
                           FROM atm."UserTransactions"
                           where "UserId" = @id
                           """;

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);
        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            string type = reader.GetString(4);
            yield return new Transaction(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetInt32(2),
                reader.GetDecimal(3),
                type == "Withdrawal" ? Operation.Withdrawal : Operation.Replenishment);
        }
    }
}
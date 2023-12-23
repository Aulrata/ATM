using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly string _connectionString;

    public AccountRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Create(Account account)
    {
        if (account is null) return;
        const string sql = """
                           INSERT INTO atm."Accounts" ("UserId", "Balance")
                           VALUES (@userId, @balance)
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("userId", account.UserId);
        command.Parameters.AddWithValue("balance", account.Balance);

        using NpgsqlDataReader reader = command.ExecuteReader();
    }

    public IEnumerable<Account> GetAllAccountsByUser(int userId)
    {
        const string sql = """
                              SELECT *
                              FROM atm."Accounts"
                              WHERE "UserId" = @userId
                              ORDER BY "Id"
                           """;

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("userId", userId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Account(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetDecimal(2));
        }
    }

    public Account? GetAccountById(int accountId)
    {
        const string sql = """
                              SELECT *
                              FROM atm."Accounts"
                              WHERE "Id" = @accountId
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("accountId", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (!reader.Read()) return null;

        return new Account(
            reader.GetInt32(0),
            reader.GetInt32(1),
            reader.GetDecimal(2));
    }

    public void UpdateBalance(int accountId, decimal newBalance)
    {
        const string sql = """
                           UPDATE atm."Accounts"
                           SET "Balance" = @balance
                           WHERE "Id" = @Id
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("balance", newBalance);
        command.Parameters.AddWithValue("Id", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();
    }
}
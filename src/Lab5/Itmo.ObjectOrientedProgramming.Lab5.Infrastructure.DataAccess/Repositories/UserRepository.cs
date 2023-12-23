using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Users;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Create(User user)
    {
        if (user is null) return;
        const string sql = """
                           INSERT INTO atm."Users" ("Login", "Password", "UserRole")
                           VALUES (@login, @password, @userRole)
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("login", user.Login);
        command.Parameters.AddWithValue("password", user.Password);
        command.Parameters.AddWithValue("userRole", user.Role.ToString());
        using NpgsqlDataReader reader = command.ExecuteReader();
    }

    public User? GetByLogin(string login)
    {
        const string sql = """
                            SELECT *
                            FROM atm."Users"
                            WHERE "Login" = @login
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("login", login);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (!reader.Read()) return null;
        string type = reader.GetString(3);
        return new User(
            reader.GetInt32(0),
            login,
            reader.GetString(2),
            type == "admin" ? UserRole.Admin : UserRole.Customer);
    }
}
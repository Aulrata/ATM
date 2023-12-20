using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Transactions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

public interface IAdminService
{
    LoginResult Login(string password);
    void CreateCustomer(string name, string lastName, string login, string password);
    IEnumerable<Transaction> ShowAllTransactionsByUser(long userId);
}
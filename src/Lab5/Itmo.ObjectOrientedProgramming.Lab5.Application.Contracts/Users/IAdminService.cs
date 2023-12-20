using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Transactions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

public interface IAdminService
{
    UserResult Login(string password);
    UserResult CreateCustomer(string name, string lastName, string login, string password);
    IEnumerable<Transaction> ShowAllTransactionsByUser(long userId);
}
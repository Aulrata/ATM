using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Accounts;

public class CurrentAccountManager
{
    public CurrentAccountManager(Account account)
    {
        Account = account;
    }

    public Account Account { get; set; }
}
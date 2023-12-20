namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;

public class Account
{
    public Account(long id, decimal balance)
    {
        Id = id;
        Balance = balance;
    }

    public long Id { get; init; }
    public decimal Balance { get; set; }
}
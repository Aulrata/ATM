namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;

public class Account
{
    public Account(int id, int userId, decimal balance)
    {
        Id = id;
        UserId = userId;
        Balance = balance;
    }

    public Account(int userId, decimal balance)
    {
        UserId = userId;
        Balance = balance;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Balance { get; set; }
}
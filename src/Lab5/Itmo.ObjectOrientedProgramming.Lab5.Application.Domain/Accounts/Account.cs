namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;

public class Account
{
    public long Id { get; init; }
    public decimal Balance { get; set; } = 0;
}
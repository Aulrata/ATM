namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Operations;

public record Operation
{
    public Operation(long id, long userId, long accountId, decimal balance, Transactions transactions)
    {
        Id = id;
        UserId = userId;
        AccountId = accountId;
        Balance = balance;
        Transactions = transactions;
    }

    public long Id { get; init; }
    public long UserId { get; set; }
    public long AccountId { get; set; }
    public decimal Balance { get; set; }
    public Transactions Transactions { get; set; }
}
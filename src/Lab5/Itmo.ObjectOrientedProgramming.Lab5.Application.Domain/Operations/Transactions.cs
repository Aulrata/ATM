namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Operations;

public record Transactions
{
    public Transactions(long id, long userId, long accountId, decimal balance, Operation operations)
    {
        Id = id;
        UserId = userId;
        AccountId = accountId;
        Balance = balance;
        Operations = operations;
    }

    public long Id { get; init; }
    public long UserId { get; set; }
    public long AccountId { get; set; }
    public decimal Balance { get; set; }
    public Operation Operations { get; set; }
}
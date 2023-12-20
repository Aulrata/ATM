namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Operations;

public class Transactions
{
    public Transactions(long id, long userId, long accountId, decimal money, Operation operations)
    {
        Id = id;
        UserId = userId;
        AccountId = accountId;
        Money = money;
        Operations = operations;
    }

    public long Id { get; init; }
    public long UserId { get; set; }
    public long AccountId { get; set; }
    public decimal Money { get; set; }
    public Operation Operations { get; set; }
}
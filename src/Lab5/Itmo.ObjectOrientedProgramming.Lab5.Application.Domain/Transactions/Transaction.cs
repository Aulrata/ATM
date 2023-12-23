namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Transactions;

public class Transaction
{
    public Transaction(int userId, int accountId, decimal money, Operation operations)
    {
        UserId = userId;
        AccountId = accountId;
        Money = money;
        Operations = operations;
    }

    public Transaction(int id, int userId, int accountId, decimal money, Operation operations)
    {
        Id = id;
        UserId = userId;
        AccountId = accountId;
        Money = money;
        Operations = operations;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public int AccountId { get; set; }
    public decimal Money { get; set; }
    public Operation Operations { get; set; }
}
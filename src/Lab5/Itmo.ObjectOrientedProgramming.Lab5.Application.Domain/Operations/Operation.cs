namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Operations;

public record Operation(long Id, long UserId, long AccountId, decimal Money, bool Refill);
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class OperationRepository : IOperationRepository
{
    public void Create(Transactions transactions)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transactions> GetAllOperationsByUser(long id)
    {
        throw new NotImplementedException();
    }
}
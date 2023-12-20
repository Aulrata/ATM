using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class OperationRepository : IOperationRepository
{
    public void Create(Operation operation)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Operation> GetAllOperationsByUser(long id)
    {
        throw new NotImplementedException();
    }
}
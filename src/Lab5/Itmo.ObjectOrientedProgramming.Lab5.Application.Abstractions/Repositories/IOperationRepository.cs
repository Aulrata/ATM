using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface IOperationRepository
{
    void Create(Operation operation);
    IEnumerable<Operation> GetAllOperationsByUser(long id);
}
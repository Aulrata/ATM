using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    void Create(User user);
    User? GetByLogin(string login);
}
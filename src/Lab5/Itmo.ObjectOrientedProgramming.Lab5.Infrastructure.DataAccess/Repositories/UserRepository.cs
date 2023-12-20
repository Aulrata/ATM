using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    public void Create(User user)
    {
        throw new NotImplementedException();
    }

    public User FindByLogin(string login)
    {
        throw new NotImplementedException();
    }
}
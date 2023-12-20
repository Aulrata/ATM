using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Users;

public class CurrentUserManager
{
    public CurrentUserManager(User user)
    {
        User = user;
    }

    public User User { get; set; }
}
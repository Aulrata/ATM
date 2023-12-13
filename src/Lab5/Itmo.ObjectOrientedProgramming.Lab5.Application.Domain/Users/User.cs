namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Users;

public record User(long Id, string UserName, string UserLastName, UserRole Role, string Login, string Password);
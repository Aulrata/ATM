namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Users;

public class User
{
    public User(string userName, string userLastName, UserRole role, string login, string password)
    {
        UserName = userName;
        UserLastName = userLastName;
        Role = role;
        Login = login;
        Password = password;
    }

    public long Id { get; init; }
    public string UserName { get; set; }
    public string? UserLastName { get; set; }
    public UserRole Role { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
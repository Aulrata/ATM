namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Users;

public class User
{
    public User(int id, string login, string password, UserRole role)
    {
        Id = id;
        Role = role;
        Login = login;
        Password = password;
    }

    public int Id { get; set; }
    public UserRole Role { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
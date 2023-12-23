using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Transactions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Users;

public class AdminService : IAdminService
{
    private readonly CurrentUserManager _currentUserManager;
    private readonly IUserRepository _userRepository;
    private readonly ITransactionRepository _transactionRepository;

    public AdminService(
        CurrentUserManager currentUserManager,
        IUserRepository userRepository,
        ITransactionRepository transactionRepository)
    {
        _currentUserManager = currentUserManager;
        _userRepository = userRepository;
        _transactionRepository = transactionRepository;
    }

    public UserResult Login(string? password)
    {
        User? user = _userRepository.GetByLogin("root");

        if (user is null) return UserResult.NotFound;

        if (user.Password != password) return UserResult.WrongPassword;

        _currentUserManager.User = user;
        return UserResult.Success;
    }

    public UserResult CreateCustomer(string? login, string? password)
    {
        if (login is null || password is null) return UserResult.NotFound;
        User? user = _userRepository.GetByLogin(login);

        if (user is not null) return UserResult.AlreadyExist;

        user = new User(0, login, password, UserRole.Customer);
        _userRepository.Create(user);
        return UserResult.Success;
    }

    public IEnumerable<Transaction>? ShowAllTransactionsByUser(int userId)
    {
        return _transactionRepository.GetAllTransactionsByUser(userId);
    }
}
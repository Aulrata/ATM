using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Transactions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Users;

public class CustomerService : ICustomerService
{
    private readonly CurrentUserManager _currentUserManager;
    private readonly CurrentAccountManager _currentAccountManager;
    private readonly IUserRepository _userRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public CustomerService(
        CurrentUserManager currentUserManager,
        CurrentAccountManager currentAccountManager,
        IUserRepository userRepository,
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository)
    {
        _currentUserManager = currentUserManager;
        _currentAccountManager = currentAccountManager;
        _userRepository = userRepository;
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public UserResult Login(string? login, string? password)
    {
        if (login is null || password is null) return UserResult.NotFound;
        User? user = _userRepository.GetByLogin(login);

        if (user is null) return UserResult.NotFound;

        if (user.Password != password) return UserResult.WrongPassword;

        _currentUserManager.User = user;
        SetDefaultAccount();
        return UserResult.Success;
    }

    public UserResult CreateAccount()
    {
        if (_currentUserManager.User is null) return UserResult.NotFound;
        var account = new Account(_currentUserManager.User.Id, 0);
        _accountRepository.Create(account);
        return UserResult.Success;
    }

    public UserResult PutMoneyIntoAccount(decimal money)
    {
        if (_currentAccountManager.Account is null || _currentUserManager.User is null) return UserResult.NotFound;
        _currentAccountManager.Account.Balance += money;

        _accountRepository.UpdateBalance(_currentAccountManager.Account.Id, _currentAccountManager.Account.Balance);

        var transaction = new Transaction(
            _currentUserManager.User.Id,
            _currentAccountManager.Account.Id,
            money,
            Operation.Replenishment);
        _transactionRepository.Create(transaction);

        return UserResult.Success;
    }

    public UserResult WithdrawMoneyFromAccount(decimal money)
    {
        if (_currentAccountManager.Account is null || _currentUserManager.User is null) return UserResult.NotFound;

        if (_currentAccountManager.Account.Balance - money < 0) return UserResult.NotEnoughMoney;
        _currentAccountManager.Account.Balance -= money;

        _accountRepository.UpdateBalance(_currentAccountManager.Account.Id, _currentAccountManager.Account.Balance);

        var transaction = new Transaction(
            _currentUserManager.User.Id,
            _currentAccountManager.Account.Id,
            money,
            Operation.Withdrawal);
        _transactionRepository.Create(transaction);

        return UserResult.Success;
    }

    public IEnumerable<Transaction>? ShowTransactionsHistory()
    {
        return _currentUserManager.User is null ? null : _transactionRepository.GetAllTransactionsByUser(_currentUserManager.User.Id);
    }

    public IEnumerable<Account>? ShowAllAccount()
    {
        return _currentUserManager.User is null ? null : _accountRepository.GetAllAccountsByUser(_currentUserManager.User.Id);
    }

    public UserResult SetCurrentAccount(int accountId)
    {
        Account? account = _accountRepository.GetAccountById(accountId);
        if (account is null) return UserResult.NotFound;

        _currentAccountManager.Account = account;
        return UserResult.Success;
    }

    public decimal ShowBalance()
    {
        return _currentAccountManager.Account?.Balance ?? -1;
    }

    private void SetDefaultAccount()
    {
        if (_currentUserManager.User is null) return;
        Account? account = _accountRepository.GetAllAccountsByUser(_currentUserManager.User.Id).FirstOrDefault();
        if (account is null) CreateAccount();
        _currentAccountManager.Account = account;
    }
}
﻿using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
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

    public UserResult Login(string login, string password)
    {
        User? user = _userRepository.GetByLogin(login);

        if (user is null) return UserResult.NotFound;

        if (user.Password != password) return UserResult.WrongPassword;

        _currentUserManager.User = user;
        return UserResult.Success;
    }

    public UserResult CreateAccount()
    {
        var account = new Account();

        _accountRepository.Create(account);
        return UserResult.Success;
    }

    public UserResult PutMoneyIntoAccount(decimal money)
    {
        _currentAccountManager.Account.Balance += money;
        return UserResult.Success;
    }

    public UserResult WithdrawMoneyFromAccount(decimal money)
    {
        if (_currentAccountManager.Account.Balance - money < 0) return UserResult.NotEnoughMoney;
        _currentAccountManager.Account.Balance -= money;
        return UserResult.Success;
    }

    public IEnumerable<Transaction> ShowTransactionsHistory()
    {
        return _transactionRepository.GetAllTransactionsByUser(_currentUserManager.User.Id);
    }

    public IEnumerable<Account> ShowAllAccount()
    {
        return _accountRepository.GetAllAccountsByUser(_currentUserManager.User.Id);
    }

    public UserResult SetCurrentAccount(long accountId)
    {
        Account? account = _accountRepository.GetAccountById(accountId);
        if (account is null) return UserResult.NotFound;

        _currentAccountManager.Account = account;
        return UserResult.Success;
    }
}
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class OperationWithBalances
{
    [Fact]
    public void Put()
    {
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();
        var currentUserManager = new CurrentUserManager();
        var user = new User(1, "1", "2", UserRole.Customer);
        currentUserManager.User = user;
        var currentAccountManager = new CurrentAccountManager();
        var account = new Account(1, 2, 100);
        currentAccountManager.Account = account;
        var customerService = new CustomerService(
            currentUserManager,
            currentAccountManager,
            userRepository,
            accountRepository,
            transactionRepository);
        customerService.PutMoneyIntoAccount(200);

        accountRepository.Received(1).UpdateBalance(account.Id, account.Balance);
        Assert.Equal(300, account.Balance);
    }

    [Fact]
    public void Take()
    {
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();
        var currentUserManager = new CurrentUserManager();
        var user = new User(1, "1", "2", UserRole.Customer);
        currentUserManager.User = user;
        var currentAccountManager = new CurrentAccountManager();
        var account = new Account(1, 2, 100);
        currentAccountManager.Account = account;
        var customerService = new CustomerService(
            currentUserManager,
            currentAccountManager,
            userRepository,
            accountRepository,
            transactionRepository);
        customerService.WithdrawMoneyFromAccount(100);

        accountRepository.Received(1).UpdateBalance(account.Id, account.Balance);
        Assert.Equal(0, account.Balance);
    }

    [Fact]
    public void TakeNoEnough()
    {
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();
        var currentUserManager = new CurrentUserManager();
        var user = new User(1, "1", "2", UserRole.Customer);
        currentUserManager.User = user;
        var currentAccountManager = new CurrentAccountManager();
        var account = new Account(1, 2, 100);
        currentAccountManager.Account = account;
        var customerService = new CustomerService(
            currentUserManager,
            currentAccountManager,
            userRepository,
            accountRepository,
            transactionRepository);
        customerService.WithdrawMoneyFromAccount(1000);

        accountRepository.Received(0).UpdateBalance(account.Id, account.Balance);
        Assert.Equal(100, account.Balance);
    }
}
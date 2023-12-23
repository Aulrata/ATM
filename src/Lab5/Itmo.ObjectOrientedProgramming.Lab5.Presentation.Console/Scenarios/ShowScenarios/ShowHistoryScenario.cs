using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Transactions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.ShowScenarios;

public class ShowHistoryScenario : BaseScenario
{
    public ShowHistoryScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string? input, ICustomerService customerService, IAdminService adminService)
    {
        if (input == Name)
        {
            Run(customerService, adminService);
            return;
        }

        base.Handle(input, customerService, adminService);
    }

    public override void Run(ICustomerService customerService, IAdminService adminService)
    {
        if (customerService is null)
        {
            System.Console.WriteLine("Customer service is null");
            return;
        }

        IEnumerable<Transaction>? accountsList = customerService.ShowTransactionsHistory();
        System.Console.WriteLine($"{"Id",5}{"AccountId",5}{"Money",10}{"Operation",20}");

        if (accountsList is null) return;

        foreach (Transaction item in accountsList)
        {
            System.Console.WriteLine($"{item.Id,5}{item.AccountId,5}{item.Money,10}{item.Operations,20}");
        }
    }
}
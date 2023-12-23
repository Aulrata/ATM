using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios;

public class ChooseScenario : BaseScenario
{
    public ChooseScenario(string name)
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

        IEnumerable<Account>? accountsList = customerService.ShowAllAccount();
        System.Console.WriteLine($"{"id",5}{"balance",20}");

        if (accountsList is null) return;

        foreach (Account item in accountsList)
        {
            System.Console.WriteLine($"{item.Id,5}{item.Balance,20}");
        }

        System.Console.WriteLine("Choose Id");
        int id = Convert.ToInt32(System.Console.ReadLine(), null);
        UserResult result = customerService.SetCurrentAccount(id);
        System.Console.WriteLine($"{result}");
    }
}
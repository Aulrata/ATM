using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios;

public class BalanceScenario : BaseScenario
{
    public BalanceScenario(string name)
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

        decimal result = customerService.ShowBalance();

        if (result == -1)
        {
            System.Console.WriteLine($"{UserResult.NotFound}");
        }

        System.Console.WriteLine($"Balance: {result}");
    }
}
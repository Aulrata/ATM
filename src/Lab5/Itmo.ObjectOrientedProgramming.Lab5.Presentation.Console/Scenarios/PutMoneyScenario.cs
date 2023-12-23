using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios;

public class PutMoneyScenario : BaseScenario
{
    public PutMoneyScenario(string name)
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

        System.Console.WriteLine("Count of money:");
        decimal money = Convert.ToDecimal(System.Console.ReadLine(), null);

        UserResult result = customerService.PutMoneyIntoAccount(money);
        System.Console.WriteLine($"{result}");
    }
}
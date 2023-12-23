using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.LoginScenarios;

public class LoginCustomerScenario : BaseScenario
{
    public LoginCustomerScenario(string name)
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

        System.Console.WriteLine("Input login");
        string? login = System.Console.ReadLine();
        System.Console.WriteLine("Input password");
        string? password = System.Console.ReadLine();

        UserResult result = customerService.Login(login, password);
        System.Console.WriteLine($"{result}");
    }
}
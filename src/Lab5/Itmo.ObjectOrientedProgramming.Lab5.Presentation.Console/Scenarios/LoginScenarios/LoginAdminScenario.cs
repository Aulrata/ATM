using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.LoginScenarios;

public class LoginAdminScenario : BaseScenario
{
    public LoginAdminScenario(string name)
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
        if (adminService is null)
        {
            System.Console.WriteLine("Admin service is null");
            return;
        }

        System.Console.WriteLine("Input password");
        string? password = System.Console.ReadLine();

        UserResult result = adminService.Login(password);
        System.Console.WriteLine($"{result}");
    }
}
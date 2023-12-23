using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.AddScenarios;

public class AddUserScenario : BaseScenario
{
    public AddUserScenario(string name)
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

        System.Console.WriteLine("Input user login");
        string? login = System.Console.ReadLine();
        System.Console.WriteLine("Input user password");
        string? password = System.Console.ReadLine();

        UserResult result = adminService.CreateCustomer(login, password);
        System.Console.WriteLine($"{result}");
    }
}
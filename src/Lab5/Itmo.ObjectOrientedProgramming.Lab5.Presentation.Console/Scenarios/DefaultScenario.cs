using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios;

public class DefaultScenario : BaseScenario
{
    public DefaultScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string? input, ICustomerService customerService, IAdminService adminService)
    {
            Run(customerService, adminService);
    }

    public override void Run(ICustomerService customerService, IAdminService adminService)
    {
        System.Console.WriteLine("Wrong command!");
    }
}
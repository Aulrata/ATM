using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console;

public class ScenarioRunner
{
    private readonly ICustomerService _customerService;
    private readonly IAdminService _adminService;
    private readonly IScenario _scenario;

    public ScenarioRunner(ICustomerService customerService, IAdminService adminService, IScenario scenario)
    {
        _customerService = customerService;
        _adminService = adminService;
        _scenario = scenario;
    }

    public void Run()
    {
        while (true)
        {
            System.Console.WriteLine("Введите команду(q=exit):");
            string? command = System.Console.ReadLine();
            if (command == "q") break;
            _scenario.Handle(command, _customerService, _adminService);
        }
    }
}
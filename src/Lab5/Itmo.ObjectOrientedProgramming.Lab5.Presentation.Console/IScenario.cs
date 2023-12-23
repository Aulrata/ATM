using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console;

public interface IScenario
{
    void Run(ICustomerService customerService, IAdminService adminService);
    void Handle(string? input, ICustomerService customerService, IAdminService adminService);
    IScenario SetNext(IScenario scenarioNode);
}
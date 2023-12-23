using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios;

public abstract class BaseScenario : IScenario
{
    protected BaseScenario(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public IScenario? NextScenario { get; private set; }

    public abstract void Run(ICustomerService customerService, IAdminService adminService);
    public virtual void Handle(string? input, ICustomerService customerService, IAdminService adminService)
    {
        NextScenario?.Handle(input, customerService, adminService);
    }

    public IScenario SetNext(IScenario scenarioNode)
    {
        NextScenario = scenarioNode;
        return this;
    }
}
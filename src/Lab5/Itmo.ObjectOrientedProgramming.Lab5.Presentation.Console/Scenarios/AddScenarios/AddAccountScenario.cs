﻿using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.AddScenarios;

public class AddAccountScenario : BaseScenario
{
    public AddAccountScenario(string name)
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

        UserResult result = customerService.CreateAccount();
        System.Console.WriteLine($"{result}");
    }
}
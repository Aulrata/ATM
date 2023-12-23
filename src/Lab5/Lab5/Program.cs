using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.AddScenarios;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.LoginScenarios;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.ShowScenarios;

string connectionString = "Host=localhost;Username=postgres;Password=12345;Database=Bank";

IAccountRepository accountRepository = new AccountRepository(connectionString);
IUserRepository userRepository = new UserRepository(connectionString);
ITransactionRepository transactionRepository = new TransactionRepository(connectionString);
var currentUserManager = new CurrentUserManager();
var currentAccountManager = new CurrentAccountManager();
IAdminService adminService = new AdminService(currentUserManager, userRepository, transactionRepository);
ICustomerService customerService = new CustomerService(
    currentUserManager,
    currentAccountManager,
    userRepository,
    accountRepository,
    transactionRepository);

IScenario scenarioChain = new LoginAdminScenario("admin");
scenarioChain
    .SetNext(new LoginCustomerScenario("customer")
    .SetNext(new PutMoneyScenario("put")
    .SetNext(new TakeMoneyScenario("take")
    .SetNext(new BalanceScenario("balance")
    .SetNext(new ShowAccountsScenario("accounts")
    .SetNext(new ShowHistoryScenario("history")
    .SetNext(new AddAccountScenario("account")
    .SetNext(new AddUserScenario("user")
    .SetNext(new ChooseScenario("choose")
    .SetNext(new DefaultScenario("default")))))))))));

var runner = new ScenarioRunner(customerService, adminService, scenarioChain);

runner.Run();
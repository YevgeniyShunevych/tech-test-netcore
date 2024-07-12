namespace Todo.E2ETests;

[Parallelizable(ParallelScope.Self)]
public class UITestFixture
{
    protected AtataContext Context { get; private set; }

    [SetUp]
    public void SetUp() =>
        Context = AtataContext.Configure().Build();

    [TearDown]
    public void TearDown() =>
        Context?.Dispose();

    protected TodoListsPage RegisterAsNewUser() =>
        Context.Report.Step("Register as a new user", x => x
            .Go.To<RegisterPage>()
            .Email.SetRandom()
            .Password.Type("Abc123!")
            .ConfirmPassword.Type("Abc123!")
            .Register.ClickAndGo());
}

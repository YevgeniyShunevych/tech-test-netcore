namespace Todo.E2ETests;

public sealed class SampleTests : UITestFixture
{
    [Test]
    public void Test()
    {
        Go.To<OrdinaryPage>()
            .PageTitle.Should.Contain("Log in");
    }
}

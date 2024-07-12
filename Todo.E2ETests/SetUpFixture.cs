using System.Net.NetworkInformation;
using Atata.Cli;

namespace Todo.E2ETests;

[SetUpFixture]
public sealed class SetUpFixture
{
    private CliCommand _dotnetRunCommand;

    [OneTimeSetUp]
    public async Task GlobalSetUp()
    {
        string driverAlias = TestContext.Parameters.Get("DriverAlias", "chrome-headless");

        // Find information on AtataContext configuration on https://atata.io/getting-started/#configuration
        // Find information on Atata JSON configuration on https://github.com/atata-framework/atata-configuration-json
        AtataContext.GlobalConfiguration
            .ApplyJsonConfig<AtataConfig>()
            .UseDriver(driverAlias)
            .UseBaseUrl(TestApp.Url);

        await Task.WhenAll(
            AtataContext.GlobalConfiguration.AutoSetUpDriverToUseAsync(),
            Task.Run(StartTestApp));
    }

    private static bool IsTestAppRunning() =>
        Array.Exists(
            IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners(),
            x => x.Port == TestApp.Port);

    private void StartTestApp()
    {
        string testAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Todo");

        FileInfo databaseFile = new(Path.Combine(testAppPath, "todo-test.db"));
        if (databaseFile.Exists)
            databaseFile.Delete();

        ProgramCli dotnetCli = new ProgramCli("dotnet", useCommandShell: true)
            .WithWorkingDirectory(testAppPath);

        dotnetCli.Execute("dotnet ef database update --no-build -- --environment LocalE2ETests");

        _dotnetRunCommand = dotnetCli.Start("run --configuration Release --launch-profile LocalE2ETests");

        var testAppWait = new SafeWait<SetUpFixture>(this)
        {
            Timeout = TimeSpan.FromSeconds(30),
            PollingInterval = TimeSpan.FromSeconds(0.2)
        };

        testAppWait.Until(_ => IsTestAppRunning());
    }

    [OneTimeTearDown]
    public void GlobalTearDown()
    {
        if (_dotnetRunCommand != null)
        {
            _dotnetRunCommand.Kill(true);
            _dotnetRunCommand.Dispose();
        }
    }
}

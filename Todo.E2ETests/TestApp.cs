namespace Todo.E2ETests;

public static class TestApp
{
    public const int Port = 51528;

    public static string Url { get; } = $"http://localhost:{Port}";
}

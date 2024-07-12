namespace Todo.E2ETests;

using _ = RegisterPage;

[Url("/Identity/Account/Register")]
public sealed class RegisterPage : Page<_>
{
    [RandomizeStringSettings("{0}@m.co")]
    public EmailInput<_> Email { get; private set; }

    public PasswordInput<_> Password { get; private set; }

    public PasswordInput<_> ConfirmPassword { get; private set; }

    public Button<TodoListsPage, _> Register { get; private set; }
}

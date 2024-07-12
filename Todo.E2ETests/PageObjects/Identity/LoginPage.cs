namespace Todo.E2ETests;

using _ = LoginPage;

[Url("/Identity/Account/Login")]
public sealed class LoginPage : Page<_>
{
    public EmailInput<_> Email { get; private set; }

    public PasswordInput<_> Password { get; private set; }

    [Term(TermCase.Sentence)]
    public Button<TodoListsPage, _> LogIn { get; private set; }
}

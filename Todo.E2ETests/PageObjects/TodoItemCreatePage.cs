namespace Todo.E2ETests;

using _ = TodoItemCreatePage;

public sealed class TodoItemCreatePage : Page<_>
{
    public TextInput<_> Title { get; private set; }

    public Select<Importance, _> Importance { get; private set; }

    public Select<string, _> Responsible { get; private set; }

    public Button<TodoListPage, _> Save { get; private set; }
}

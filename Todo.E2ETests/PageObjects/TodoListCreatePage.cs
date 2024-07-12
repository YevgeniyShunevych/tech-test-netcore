namespace Todo.E2ETests;

using _ = TodoListCreatePage;

[Url("/TodoList/Create")]
public sealed class TodoListCreatePage : Page<_>
{
    public TextInput<_> Title { get; private set; }

    public Button<TodoItemCreatePage, _> Save { get; private set; }
}

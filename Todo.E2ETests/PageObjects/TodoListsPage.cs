namespace Todo.E2ETests;

using _ = TodoListsPage;

[Url("/TodoList")]
public sealed class TodoListsPage : Page<_>
{
    public Link<TodoListCreatePage, _> AddNewList { get; private set; }

    public TodoItemCreatePage AddNewListAndGoToItemCreatePage() =>
        AddNewList.ClickAndGo()
            .Title.SetRandom()
            .Save.ClickAndGo();
}

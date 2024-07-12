namespace Todo.E2ETests;

using _ = TodoListPage;

public sealed class TodoListPage : Page<_>
{
    public Link<TodoItemCreatePage, _> AddNewItem { get; private set; }

    public ControlList<TodoItem, _> Items { get; private set; }

    [Term(TermCase.Sentence)]
    public CheckBox<_> HideDoneItems { get; private set; }

    [ControlDefinition("li[@data-is-done]", ComponentTypeName = "item", Visibility = Visibility.Visible)]
    public sealed class TodoItem : ListItem<_>
    {
        [FindFirst]
        public Link<TodoItemEditPage, _> Title { get; private set; }

        public TodoItemEditPage Edit() =>
            Title.ClickAndGo();
    }
}

using Todo.Data.Entities;
using Todo.Models.TodoItems;

namespace Todo.Tests;

public sealed record class TodoItemTestModel(string Title, Importance Importance)
{
    public static TodoItemTestModel Create(TodoItemSummaryViewmodel viewmodel) =>
        new(viewmodel.Title, viewmodel.Importance);
}

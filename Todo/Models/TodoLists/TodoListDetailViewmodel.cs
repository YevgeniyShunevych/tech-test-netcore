using System.Collections.Generic;
using Todo.Models.TodoItems;

namespace Todo.Models.TodoLists
{
    public class TodoListDetailViewmodel
    {
        public int TodoListId { get; }
        public string Title { get; }
        public IReadOnlyList<TodoItemSummaryViewmodel> Items { get; }

        public TodoListDetailViewmodel(int todoListId, string title, IReadOnlyList<TodoItemSummaryViewmodel> items)
        {
            Items = items;
            TodoListId = todoListId;
            Title = title;
        }
    }
}

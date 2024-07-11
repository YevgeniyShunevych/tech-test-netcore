using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Todo.Data.Entities;

namespace Todo.Tests
{
    /// <summary>
    /// This class makes it easier for tests to create new TodoLists with TodoItems correctly hooked up.
    /// </summary>
    public sealed class TestTodoListBuilder
    {
        private readonly string title;

        private readonly IdentityUser owner;

        private readonly List<TodoItemTestModel> items = new();

        public TestTodoListBuilder(IdentityUser owner, string title)
        {
            this.title = title;
            this.owner = owner;
        }

        public static TestTodoListBuilder CreateEmpty() =>
            new(new("alice@example.com"), "Shopping");

        public TestTodoListBuilder AddItem(TodoItemTestModel item)
        {
            items.Add(item);
            return this;
        }

        public TestTodoListBuilder AddItems(params TodoItemTestModel[] items)
        {
            foreach (var item in items)
                this.items.Add(item);

            return this;
        }

        public TodoList Build()
        {
            var todoList = new TodoList(owner, title);

            var todoItems = items.Select((x, i) =>
                new TodoItem(todoList.TodoListId, owner.Id, x.Title, x.Importance)
                {
                    TodoItemId = i + 1,
                    ResponsibleParty = owner,
                    TodoList = todoList
                });

            foreach (var item in todoItems)
                todoList.Items.Add(item);

            return todoList;
        }
    }
}

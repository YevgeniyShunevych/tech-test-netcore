using System.Linq;
using FluentAssertions;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoItems;
using Xunit;

namespace Todo.Tests;

public sealed class TodoItemEditFieldsFactoryTests
{
    [Fact]
    public void Create()
    {
        // Arrange
        TodoList todoList = TestTodoListBuilder.CreateEmpty()
            .AddItem(new("Bread", Importance.High))
            .Build();

        var sourceItem = todoList.Items.First();

        // Act
        var result = TodoItemEditFieldsFactory.Create(sourceItem);

        // Assert
        result.Should().BeEquivalentTo(new TodoItemEditFields
        {
            TodoListId = sourceItem.TodoListId,
            TodoListTitle = sourceItem.TodoList.Title,
            TodoItemId = sourceItem.TodoItemId,
            Title = sourceItem.Title,
            IsDone = sourceItem.IsDone,
            ResponsiblePartyId = sourceItem.ResponsiblePartyId,
            Importance = sourceItem.Importance
        });
    }
}

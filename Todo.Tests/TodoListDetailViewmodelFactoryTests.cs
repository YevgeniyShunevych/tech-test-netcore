using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoLists;
using Xunit;

namespace Todo.Tests;

public sealed class TodoListDetailViewmodelFactoryTests
{
    [Fact]
    public void Create()
    {
        // Arrange
        TodoItemTestModel bread = new("Bread", Importance.Medium);
        TodoItemTestModel water = new("Water", Importance.High);
        TodoItemTestModel butter = new("Butter", Importance.Medium);
        TodoItemTestModel salt = new("Salt", Importance.Low);

        TodoList todoList = TestTodoListBuilder.CreateEmpty()
            .AddItems(bread, water, butter, salt)
            .Build();

        // Act
        var result = TodoListDetailViewmodelFactory.Create(todoList);

        // Assert
        using (new AssertionScope())
        {
            result.TodoListId.Should().Be(todoList.TodoListId);
            result.Title.Should().Be(todoList.Title);
            result.Items.Select(TodoItemTestModel.Create).Should().BeEquivalentTo(
                [water, bread, butter, salt]);
        }
    }
}

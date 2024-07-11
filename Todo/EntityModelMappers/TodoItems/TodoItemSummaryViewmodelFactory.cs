using Todo.Data.Entities;
using Todo.Models.TodoItems;

namespace Todo.EntityModelMappers.TodoItems
{
    public static class TodoItemSummaryViewmodelFactory
    {
        public static TodoItemSummaryViewmodel Create(TodoItem item) =>
            new(
                item.TodoItemId,
                item.Title,
                item.IsDone,
                UserSummaryViewmodelFactory.Create(item.ResponsibleParty),
                item.Importance);
    }
}

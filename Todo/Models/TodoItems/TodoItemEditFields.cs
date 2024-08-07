﻿using System.ComponentModel.DataAnnotations;
using Todo.Data.Entities;

namespace Todo.Models.TodoItems
{
    public class TodoItemEditFields
    {
        public int TodoListId { get; set; }

        public string TodoListTitle { get; set; }

        public int TodoItemId { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Done")]
        public bool IsDone { get; set; }

        [Display(Name = "Responsible")]
        public string ResponsiblePartyId { get; set; }

        public Importance Importance { get; set; }

        public TodoItemEditFields() { }

        public TodoItemEditFields(
            int todoListId,
            string todoListTitle,
            int todoItemId,
            string title,
            bool isDone,
            string responsiblePartyId,
            Importance importance)
        {
            TodoListId = todoListId;
            TodoListTitle = todoListTitle;
            TodoItemId = todoItemId;
            Title = title;
            IsDone = isDone;
            ResponsiblePartyId = responsiblePartyId;
            Importance = importance;
        }
    }
}

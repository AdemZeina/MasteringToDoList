using System;
using System.Collections.Generic;
using System.Text;
using masteringToDoList.Core.Entities;

namespace masteringToDoList.Application.Models
{
    public class ToDoListModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }

        public List<ToDoItemModel> Items { get; set; }
    }

    public class ToDoItemModel
    {
        public string Description { get; set; }

        public Status Status { get; set; }
        public DateTime DeadLine { get; set; }
    }
}

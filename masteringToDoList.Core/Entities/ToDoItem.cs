using System;
using System.Collections.Generic;
using System.Text;
using masteringToDoList.Core.Entities.Base;

namespace masteringToDoList.Core.Entities
{
    public enum Status
    {
        Draft=0,
        InProgress=1,
        Complete=2
    }
    public class ToDoItem:Entity
    {
        public string Description { get; set; }

        public Status Status { get; set; }
        public DateTime DeadLine { get; set; }
        public ToDoList ToDoList { get; set; }
    }
}

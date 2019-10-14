using System;
using System.Collections.Generic;
using System.Text;
using masteringToDoList.Core.Entities.Base;

namespace masteringToDoList.Core.Entities
{
    public class ToDoList:Entity
    {
        public string Name { get; set; }
        public ApplicationUser User { get; set; }

        public List<ToDoItem> Items { get; set; }
    }
}

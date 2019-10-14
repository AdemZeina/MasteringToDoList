using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using masteringToDoList.Core.Entities;
using masteringToDoList.Core.Specifications.Base;

namespace masteringToDoList.Core.Specifications
{
    public class ToDoListWithItemspecifications : BaseSpecification<ToDoList>
    {
        public ToDoListWithItemspecifications(Expression<Func<ToDoList, bool>> criteria) : base(criteria)
        {
        }

        public ToDoListWithItemspecifications(string userEmail)
            : base(p => p.User.Email == userEmail)
        {
            AddInclude(p => p.Items);
        }

        public ToDoListWithItemspecifications(Guid listId)
            : base(p => p.Id == listId)
        {
            AddInclude(p => p.Items);
        }

        public ToDoListWithItemspecifications()
            : base(null)
        {
            AddInclude(p => p.Items);
        }
    }
}

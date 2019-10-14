using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using masteringToDoList.Core.Entities;
using masteringToDoList.Core.Specifications.Base;

namespace masteringToDoList.Core.Specifications
{
    public class ToDoListOfCurrentUserSpecification : BaseSpecification<ToDoList>
    {
        public ToDoListOfCurrentUserSpecification(Expression<Func<ToDoList, bool>> criteria) : base(criteria)
        {
        }

        public ToDoListOfCurrentUserSpecification(string userEmail)
            : base(p => p.User.Email == userEmail)
        {
            AddInclude(p => p.Items);
            AddInclude(e=>e.User);
        }
    }
}

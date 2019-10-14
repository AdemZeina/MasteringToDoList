using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using masteringToDoList.Core.Entities;

namespace masteringToDoList.Core.Repository
{
    public interface IToDoListRepository:IRepository<ToDoList>
    {
        Task<List<ToDoList>> GetAllListsOfCurrentUser(string userEmail);
    }
}

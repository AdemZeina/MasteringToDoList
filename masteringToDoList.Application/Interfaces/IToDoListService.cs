using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using masteringToDoList.Application.Models;

namespace masteringToDoList.Application.Interfaces
{
    public interface IToDoListService
    {
        Task<List<ToDoListModel>> GetAllListsOfCurrentUser(string userEmail);
    }
}

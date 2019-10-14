using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using masteringToDoList.Application.Interfaces;
using masteringToDoList.Application.Mapper;
using masteringToDoList.Application.Models;
using masteringToDoList.Core.Entities;
using masteringToDoList.Core.Repository;

namespace masteringToDoList.Application.Services
{
    public class ToDoListService: IToDoListService
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListService(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public async Task<List<ToDoListModel>> GetAllListsOfCurrentUser(string userEmail)
        {
            var toDolist=await _toDoListRepository.GetAllListsOfCurrentUser(userEmail);
            List<ToDoListModel> toDolistModel = ObjectMapper.Mapper.Map<List<ToDoListModel>>(toDolist);
            return toDolistModel;
        }
    }
}

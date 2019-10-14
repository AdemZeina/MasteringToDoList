using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using masteringToDoList.Application.Interfaces;
using masteringToDoList.Application.Models;
using masteringToDoList.Core.Entities;
using masteringToDoList.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace masteringToDoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly ToDoListDbContext _context;
        private readonly IToDoListService _toDoListService;
        private readonly ILogger<ToDoListsController> _logger;
        public ToDoListsController(ToDoListDbContext context, IToDoListService toDoListService, ILogger<ToDoListsController> logger)
        {
            _context = context;
            _toDoListService = toDoListService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<List<ToDoListModel>> GetToDoLists()
        {
            List<ToDoListModel> items = await _toDoListService.GetAllListsOfCurrentUser("adem@htomail.com");
            return items;
        }


    }
}
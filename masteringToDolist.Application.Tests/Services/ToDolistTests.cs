using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using masteringToDoList.Application.Services;
using masteringToDoList.Core.Interfaces;
using masteringToDoList.Core.Repository;
using Moq;
using Xunit;

namespace masteringToDolist.Application.Tests.Services
{
    public class ToDoListTests
    {
        private Mock<IToDoListRepository> _mockToDoListRepository;
        private Mock<IAppLogger<ToDoListService>> _mockAppLogger;

        public ToDoListTests(Mock<IToDoListRepository> mockToDoListRepository, Mock<IAppLogger<ToDoListService>> mockAppLogger)
        {
            _mockToDoListRepository = mockToDoListRepository;
            _mockAppLogger = mockAppLogger;
        }


        [Fact]
        public async Task Get_ToDo_List()
        {
            //Test code
        }

        [Fact]
        public async Task Create_New_List()
        {
            //Test code
        }
    }
}

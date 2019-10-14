using masteringToDoList.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using masteringToDoList.Core.Entities;
using masteringToDoList.Core.Repository;
using masteringToDoList.Core.Specifications;
using masteringToDoList.Infrastructure.Data;

namespace masteringToDoList.Infrastructure.Repository
{
    public class ToDoListRepository:Repository<ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(ToDoListDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ToDoList>> GetProductListAsync()
        {
            var spec = new ToDoListWithItemspecifications();
            return await GetAsync(spec);

            // second way
            // return await GetAllAsync();
        }

        public async Task<List<ToDoList>> GetAllListsOfCurrentUser(string userEmail)
        {
            var spec = new ToDoListOfCurrentUserSpecification(userEmail); 
            var res=(List<ToDoList>) await GetAsync(spec);
            return res;
        }
    }
}

using Abp.EntityFramework;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using System;
using SimpleTaskSystem.Entities.Task;
using System.Data.Entity;
using SimpleTaskSystem.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTaskSystem.EntityFramework.Repositories
{
    class TaskRepository : SimpleTaskSystemRepositoryBase<Tasks, long>, ITaskRepository
    {
        public TaskRepository(IDbContextProvider<SimpleTaskSystemDbContext> dbContextProvider)
            : base(dbContextProvider) { }

        public List<Tasks> GetAllWithPeople(int? assignedId, TaskState? state)
        {
            var query = GetAll();

            if (assignedId.HasValue)
            {
                query = query.Where(Tasks => Tasks.AssignedPerson.Id == assignedId.Value);
            }

            if (state.HasValue)
            {
                query = query.Where(task => task.State == state);
            }

            return query.OrderByDescending(task => task.CreationTime).Include(task => task.AssignedPerson).ToList();
        }
    }
}

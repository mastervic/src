using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.Entities.Task
{
    public interface ITaskRepository : IRepository<Tasks, long>
    {
        List<Tasks> GetAllWithPeople(int? assignedPersonId, TaskState? state);
    }
}

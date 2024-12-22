using Domain.Models;
using Domain.Interfaces;

namespace DataAccess.Repositories
{
    public class TasksRepository : RepositoryBase<Domain.Models.Task>, ITasksRepository
    {
        public TasksRepository(SmirnovaPlanGoDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}

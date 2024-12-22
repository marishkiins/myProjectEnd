using Domain.Models;
using Domain.Interfaces;
using DataAccess.Repositories;
using Tasks = System.Threading.Tasks.Task;


namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SmirnovaPlanGoDbContext _repoContext;
        private IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }



        private ITasksRepository _task;
        public ITasksRepository Task
        {
            get
            {
                if (_task == null)
                {
                    _task = new TasksRepository(_repoContext);
                }
                return _task;
            }
        }

        public RepositoryWrapper(SmirnovaPlanGoDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Tasks Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}

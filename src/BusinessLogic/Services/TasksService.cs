using Domain.Interfaces;
using Domain.Models;
using Tasks = System.Threading.Tasks.Task;

namespace BusinessLogic.Services
{
    public class TasksService : ITasksService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TasksService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Domain.Models.Task>> GetAll()
        {
            return await _repositoryWrapper.Task.FindAll();
        }

        public async Task<Domain.Models.Task> GetById(int id)
        {
            var task = await _repositoryWrapper.Task
                .FindByCondition(x => x.Id == id);
            return task.First();
        }

        public async Tasks Create(Domain.Models.Task model)
        {
            await _repositoryWrapper.Task.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Tasks Update(Domain.Models.Task model)
        {
            await _repositoryWrapper.Task.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Tasks Delete(int id)
        {
            var task = await _repositoryWrapper.Task
                .FindByCondition(x => x.Id == id);

            await _repositoryWrapper.Task.Delete(task.First());
            await _repositoryWrapper.Save();
        }
    }
}

using Task = System.Threading.Tasks.Task;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ITasksService
    {
        Task<List<Models.Task>> GetAll();
        Task<Models.Task> GetById(int id);
        Task Create(Models.Task model);
        Task Update(Models.Task model);
        Task Delete(int id);
    }
}


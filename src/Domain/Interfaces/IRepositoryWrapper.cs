using Domain.Interfaces;


namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User {  get; }
        ITasksRepository Task { get; }
        Task Save();



    }
}

using TaskForge.Api.Models;

namespace TaskForge.Api.Services
{
    public interface ITaskService
    {

        Task<List<TaskItem>> GetAll();

        Task<TaskItem> GetById(int id);

        Task<TaskItem> Create(TaskItem item);

        Task<bool> Update(int id, TaskItem item);

        Task<bool> Delete(int id);
    }
}
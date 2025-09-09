using TaskForge.Api.Models;

namespace TaskForge.Api.Services
{
    public class TaskService : ITaskService
    {
        // English: seed dictionary with some demo tasks
        private readonly Dictionary<int, TaskItem> _tasks = new()
        {
            { 1, new TaskItem { Id = 1, Title = "Task 1", Description = "Buy groceries", IsDone = false, Priority = 1, Tags = new() { "home", "shopping" }, DueDate = DateTime.Now.AddDays(1) } },
            { 2, new TaskItem { Id = 2, Title = "Task 2", Description = "Finish project report", IsDone = true, Priority = 2, Tags = new() { "work" }, DueDate = DateTime.Now.AddDays(2) } },
            { 3, new TaskItem { Id = 3, Title = "Task 3", Description = "Clean the garage", IsDone = false, Priority = 3, Tags = new() { "home" }, DueDate = DateTime.Now.AddDays(3) } },
            { 4, new TaskItem { Id = 4, Title = "Task 4", Description = "Prepare Mongo lesson", IsDone = true, Priority = 1, Tags = new() { "teaching" }, DueDate = DateTime.Now.AddDays(4) } },
            { 5, new TaskItem { Id = 5, Title = "Task 5", Description = "Call the bank", IsDone = false, Priority = 2, Tags = new() { "finance" }, DueDate = DateTime.Now.AddDays(5) } }
        };

        private int _nextId = 6;

        public Task<List<TaskItem>> GetAll()
        {
            return Task.FromResult(_tasks.Values.ToList());
        }

        public Task<TaskItem> GetById(int id)
        {
            _tasks.TryGetValue(id, out var task);
            return Task.FromResult(task);
        }

        public Task<TaskItem> Create(TaskItem item)
        {
            item.Id = _nextId++;
            _tasks[item.Id] = item;
            return Task.FromResult(item);
        }

        public Task<bool> Update(int id, TaskItem item)
        {
            if (!_tasks.ContainsKey(id)) return Task.FromResult(false);

            item.Id = id; // English: ensure Id stays consistent
            _tasks[id] = item;
            return Task.FromResult(true);
        }

        public Task<bool> Delete(int id)
        {
            return Task.FromResult(_tasks.Remove(id));
        }
    }
}


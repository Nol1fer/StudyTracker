using StudyTracker.Repositories;

namespace StudyTracker.Services
{
    public class TaskService
    {
        private readonly TaskRepository _repository;

        public TaskService(TaskRepository repository)
        {
            _repository = repository;
        }

        public Models.Task? GetTaskById(int id) => _repository.GetTaskById(id);
        public void AddTask(Models.Task task) => _repository.AddTask(task);
        public List<Models.Task> GetTasksByCourseId(int courseId) => _repository.GetTasksByCourseId(courseId);
        public void UpdateTask(Models.Task task) => _repository.UpdateTask(task);
        public void DeleteTask(int id) => _repository.DeleteTask(id);
    }
}
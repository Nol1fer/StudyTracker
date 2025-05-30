namespace StudyTracker.Repositories
{
    public class TaskRepository
    {
        private static List<Models.Task> _tasks = new List<Models.Task>();

        public Models.Task? GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }
        public void AddTask(Models.Task task)
        {
            task.Id = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(task);
        }

        public List<Models.Task> GetTasksByCourseId(int courseId)
        {
            return _tasks.Where(t => t.CourseId == courseId).ToList();
        }

        public void UpdateTask(Models.Task updatedTask)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (task != null)
            {
                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.Deadline = updatedTask.Deadline;
                task.Status = updatedTask.Status;
            }
        }

        public void DeleteTask(int id)
        {
            _tasks.RemoveAll(t => t.Id == id);
        }
    }
}
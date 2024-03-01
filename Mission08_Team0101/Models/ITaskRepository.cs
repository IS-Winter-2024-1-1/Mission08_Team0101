namespace Mission08_Team0101.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }
        List<Task> Categories { get; }

        public void AddTask(Task task);
        public void RemoveTask(Task task);
        public void UpdateTask(Task task);

    }
}

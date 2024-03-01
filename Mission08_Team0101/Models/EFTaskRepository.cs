namespace Mission08_Team0101.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskApplicationContext _context;
        public EFTaskRepository(TaskApplicationContext temp)
        {
            _context = temp;
        }

        public List<Task> Tasks => _context.Tasks.ToList();

        public List<Category> Categories => _context.Categories.ToList();

        public void AddTask(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void RemoveTask(Task task)
        {
            _context.Remove(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }
    }
}

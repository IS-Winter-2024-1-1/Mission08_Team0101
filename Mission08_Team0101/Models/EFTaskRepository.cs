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
    }
}

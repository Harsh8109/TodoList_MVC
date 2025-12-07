using TodoList.Models;

namespace TodoList.Repository
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        // In-Memory list to store todo items
        private readonly List<TodoItem> _todos = new List<TodoItem>();

        // Tracks the next available ID for new todo items
        private int _nextId = 1;

        public List<TodoItem> GetAll()
        {
            return _todos;
        }

        public TodoItem? GetById(int id)
        {
            return _todos.FirstOrDefault(todo => todo.Id == id);
        }

        public void Add(TodoItem item)
        {
            item.Id = _nextId++;
            _todos.Add(item);
        }

        public void Update(TodoItem item)
        {
            var existing = GetById(item.Id);
            if(existing != null)
            {
                existing.Title = item.Title;
                existing.Description = item.Description;
                existing.IsCompleted = item.IsCompleted;
            }
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _todos.Remove(item);
            }
            
        }
        
    }
}

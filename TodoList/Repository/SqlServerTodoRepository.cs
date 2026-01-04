using TodoList.Data;
using TodoList.Models;

namespace TodoList.Repository
{
    public class SqlServerTodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;
        public SqlServerTodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        // retrieve all todo items from the database
        public List<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        // retrieve a specific todo item by its ID from the database
        public TodoItem? GetById(int id)
        {
            return _context.TodoItems.FirstOrDefault(todo => todo.Id == id);
        }

        // add a new todo item to the database
        public void Add(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
        }

        // update an existing todo item in the database
        public void Update(TodoItem item)
        {
            var existing = _context.TodoItems.FirstOrDefault(todo => todo.Id == item.Id);

            if(existing != null)
            {
                existing.Title = item.Title;
                existing.Description = item.Description;
                existing.IsCompleted = item.IsCompleted;
                _context.SaveChanges();
            }
        }

        // delete a todo item from the database by its ID
        public void Delete(int id)
        {
            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if(todo != null)
            {
                _context.TodoItems.Remove(todo);
                _context.SaveChanges();
            }
        }

    }
}

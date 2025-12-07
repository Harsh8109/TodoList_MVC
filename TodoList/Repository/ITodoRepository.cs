using TodoList.Models;

namespace TodoList.Repository
{
    public interface ITodoRepository
    {
        // Retrieves all todo items from the repository
        List<TodoItem> GetAll();

        // Retrieves a specific todo item by its ID
        TodoItem? GetById(int id);

        // Adds a new todo item to the repository
        void Add(TodoItem item);

        // Updates an existing todo item in the repository
        void Update(TodoItem item);

        // Deletes a todo item from the repository by its ID
        void Delete(int id);
    }
}

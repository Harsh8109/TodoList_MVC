using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Repository;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        // Repository interface injected via Dependency Injection
        private readonly ITodoRepository _repository;

        // Constructor injection of the repository
        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // GET: /Todo/ - Displays the list of todo items
        public IActionResult Index()
        {
            var todos = _repository.GetAll();
            return View(todos);
        }

        // GET: /Todo/Create - Displays the form to create a new todo item
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Todo/Create - Handles the submission of a new todo item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoItem todo)
        {
            // Validate that the title is not empty
            if (string.IsNullOrEmpty(todo.Title))
            {
                ModelState.AddModelError("Title", "Title is required.");
            }

            if (ModelState.IsValid)
            {
                _repository.Add(todo);
                TempData["SuccessMessage"] = "Todo item created successfuly!";
                return RedirectToAction(nameof(Index));
            }

            return View(todo);
        }

        // GET: /Todo/Edit/{id} - Displays the form to edit an existing todo item
        public IActionResult Edit(int id)
        {
            var todo = _repository.GetById(id);
            if(todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: /Todo/Edit/{id} - Handles the submission of an edited todo item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TodoItem todo)
        {
            // validate that the title is not empty
            if (string.IsNullOrEmpty(todo.Title))
            {
                ModelState.AddModelError("Title", "Title is required.");
            }
            if (ModelState.IsValid)
            {
                _repository.Update(todo);
                TempData["SuccessMessage"] = "Todo item updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(todo);
        }

        // GET: /Todo/Delete/{id} - Shows the confirmation page to delete a todo item
        public IActionResult Delete(int id)
        {
            var todo = _repository.GetById(id);
            if(todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: /Todo/Delete/{id} - Handles the deletion of a todo item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _repository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            _repository.Delete(id);
            TempData["SuccessMessage"] = "Todo item deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ToDoList.Contracts;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _repo;

        public ToDoController(IToDoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var toDos = await _repo.GetAllAsync();
            return View(toDos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return View(toDo);
            }
            _repo.Add(toDo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var toDo = await _repo.GetByIdAsync(id);
            if (toDo == null)
            {
                return View("Error");
            }
            return View(toDo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDo = await _repo.GetByIdAsync(id);
            _repo.Delete(toDo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(ToDo toDo)
        {
            if(!ModelState.IsValid)
            {
                return View(toDo);
            }
            _repo.Update(toDo);
            return RedirectToAction("Index");
        }
    }
}

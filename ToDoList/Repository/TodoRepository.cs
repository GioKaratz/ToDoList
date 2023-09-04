using Microsoft.EntityFrameworkCore;
using ToDoList.Contracts;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class TodoRepository : IToDoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(ToDo toDo)
        {
            _context.Add(toDo);
            return Save();
        }

        public bool Delete(ToDo toDo)
        {
            _context.Remove(toDo);
            return Save();
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            return await _context.toDos.ToListAsync();
        }

        public async Task<ToDo> GetByIdAsync(int id)
        {
            return await _context.toDos.FirstOrDefaultAsync(q => q.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(ToDo toDo)
        {
            _context.Update(toDo);
            return Save();
        }
    }
}

using ToDoList.Models;

namespace ToDoList.Contracts
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDo>> GetAllAsync();
        Task<ToDo> GetByIdAsync(int id);
        bool Add(ToDo toDo);
        bool Update(ToDo toDo);
        bool Delete(ToDo toDo);
        bool Save();
    }
}

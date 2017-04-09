using LinkMyTravel.WebAPI.Model;
using System.Collections.Generic;

namespace LinkMyTravel.WebAPI.Repositories
{
    public interface ITodoRepository
    {
        TodoItem Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(int key);
        void Remove(int key);
        TodoItem Update(TodoItem item);
    }
}
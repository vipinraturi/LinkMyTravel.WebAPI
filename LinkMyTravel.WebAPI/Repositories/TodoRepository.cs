using LinkMyTravel.Data;
using LinkMyTravel.WebAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace LinkMyTravel.WebAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly LinkMyTravelContext _context;

        public TodoRepository(LinkMyTravelContext context)
        {
            _context = context;
            //Add(new TodoItem {  Name = "Item1", IsComplete=false });
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        public TodoItem Add(TodoItem item)
        {
            var itemFromDb = _context.TodoItems.Add(item);
            _context.SaveChanges();
            return itemFromDb.Entity;
        }

        public TodoItem Find(int key)
        {
            return _context.TodoItems.FirstOrDefault(t => t.Key == key);
        }

        public void Remove(int key)
        {
            var entity = _context.TodoItems.First(t => t.Key == key);
            _context.TodoItems.Remove(entity);
            _context.SaveChanges();
        }

        public TodoItem Update(TodoItem item)
        {
            var itemFromDb = _context.TodoItems.Update(item);
            _context.SaveChanges();
            return itemFromDb.Entity;
        }
    }
}

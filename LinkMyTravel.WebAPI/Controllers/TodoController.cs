using LinkMyTravel.WebAPI.Model;
using LinkMyTravel.WebAPI.Repositories;
using LinkMyTravel.WebAPI.Utilities;
using LinkMyTravel.WebAPI.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkMyTravel.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class TodoController : Controller
    {
        ITodoRepository _todoRepository = null;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            var response = new ResultSet();
            response.Message = "Test";
            try
            {
                var items = _todoRepository.GetAll();
                if (items == null)
                {
                    response.DidError = true;
                    response.ErrorMessage = "No result to return";
                }
                else
                {
                    response.List = items;
                }

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }
            return response.List;
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new SingleModelResponse<TodoItem>() as ISingleModelResponse<TodoItem>;
            try
            {
                var item = _todoRepository.Find(id);
                if (item == null)
                {
                    response.DidError = true;
                    response.ErrorMessage = "Value cannot be null";
                }
                else
                {
                    response.Model = item;
                }

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();

            //var item = _todoRepository.Find(id);
            //if (item == null)
            //{
            //    return NotFound();
            //}
            //return new ObjectResult(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoItem item)
        {
            var response = new SingleModelResponse<TodoItem>() as ISingleModelResponse<TodoItem>;
            TodoItem itemJustInserted = null;

            if (item == null)
            {
                response.DidError = true;
                response.ErrorMessage = "Cannot pass null value";
            }

            try
            {
                itemJustInserted = _todoRepository.Add(item);
                response.Message = "Inserted Successfully!";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            response.Model = _todoRepository.Find(itemJustInserted.Key);

            return response.ToHttpResponse();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoItem item)
        {
            var response = new SingleModelResponse<TodoItem>() as ISingleModelResponse<TodoItem>;
            TodoItem itemJustInserted = null;

            if (item == null)
            {
                response.DidError = true;
                response.ErrorMessage = "Cannot pass null value";
            }

            try
            {
                itemJustInserted = _todoRepository.Update(item);
                response.Message = "Updated Successfully!";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            response.Model = _todoRepository.Find(itemJustInserted.Key);

            return response.ToHttpResponse();

            //if (item == null || item.Key != id)
            //{
            //    return BadRequest();
            //}

            //var todo = _todoRepository.Find(id);
            //if (todo == null)
            //{
            //    return NotFound();
            //}

            //todo.IsComplete = item.IsComplete;
            //todo.Name = item.Name;

            //_todoRepository.Update(todo);
            //return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = new SingleModelResponse<TodoItem>() as ISingleModelResponse<TodoItem>;

            try
            {

                var todo = _todoRepository.Find(id);
                if (todo == null)
                {
                    return NotFound();
                }

                response.Message = "Deleted Successfully!";
                _todoRepository.Remove(id);

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();

            //var todo = _todoRepository.Find(id);
            //if (todo == null)
            //{
            //    return NotFound();
            //}

            //_todoRepository.Remove(id);
            //return new NoContentResult();
        }
    }
}
using System;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {
            
        }

        public IEnumerable<TodoItem> GetAll(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string email)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("Titulo aqui", "ryoji@gmail.com", DateTime.Now);
        }

        public IEnumerable<TodoItem> GetByPeriod(string email, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem todo)
        {
            
        }
    }
}
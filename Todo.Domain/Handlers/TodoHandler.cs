using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsOndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        
        public ICommandResult Handle(CreateTodoCommand command)
        {
           // Fail Fast Validation
           command.Validate();

           if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, para que sua tarefa está errada",
                    command.Notifications
                );

           // Gerar um TodoItem

           var todo = new TodoItem(command.Title, command.User, command.Date);

           // Salvar no banco
           _repository.Create(todo);

           // Notificar o usuario

           return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail Fast Validation
           command.Validate();

           if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, para que sua tarefa está errada",
                    command.Notifications
                );

           // Recupera o TodoItem (Reidratação)

           var todo = _repository.GetById(command.Id, command.User);

           // Alter o Titulo
           todo.UpdateTitle(command.Title);

           // salva no banco 
           _repository.Update(todo);

           // Retorna o resultado

           return new GenericCommandResult(true, "Tarefa atualizada", todo);
        }

        public ICommandResult Handle(MarkTodoAsOndoneCommand command)
        {
             // Fail Fast Validation
           command.Validate();

           if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, para que sua tarefa está errada",
                    command.Notifications
                );

           // Recupera o TodoItem (Reidratação)

           var todo = _repository.GetById(command.Id, command.User);

           // Alter o Titulo
           todo.MarkAsDone();

           // salva no banco 
           _repository.Update(todo);

           // Retorna o resultado

           return new GenericCommandResult(true, "Tarefa atualizada", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
              // Fail Fast Validation
           command.Validate();

           if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, para que sua tarefa está errada",
                    command.Notifications
                );

           // Recupera o TodoItem (Reidratação)

           var todo = _repository.GetById(command.Id, command.User);

           // Alter o Titulo
           todo.MarkAsUndone();

           // salva no banco 
           _repository.Update(todo);

           // Retorna o resultado

           return new GenericCommandResult(true, "Tarefa atualizada", todo);
        }
    }
}
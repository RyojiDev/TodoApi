using System;

namespace Todo.Domain.Commands.Contracts
{
    public class CreateTodoCommand
    {
        public CreateTodoCommand() { }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get;  set; }
        public DateTime Date { get;  set; }
        public string User { get;  set; }

    }
}
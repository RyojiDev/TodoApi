using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now); 
        private readonly CreateTodoCommand _validCommand   = new CreateTodoCommand("Estudar c#", "ryoji@gmail.com", DateTime.Now);
        private GenericCommandResult _result = new GenericCommandResult();

        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        [TestMethod]
        public void Dado_Um_Comando_invalido_deve_interromper_a_execucao ()
        {
            
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);

            // Assert
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_Um_Comando_invalido_deve_criar_a_tarefa ()
        {
            // Act
            _result  = (GenericCommandResult)_handler.Handle(_validCommand);

            //Assert
            Assert.AreEqual(_result.Success, true);
        }
    }
}
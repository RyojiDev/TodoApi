using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Estudar c#", "ryoji@gmail.com", DateTime.Now);
       
        [TestMethod]
        public void Dado_um_Comando_Invalido()
        { 
           // Act
           _invalidCommand.Validate();

           // Assert
           Assert.AreEqual(_invalidCommand.Valid, false);
        }

         [TestMethod]
        public void Dado_um_Comando_Valido()
        {
            // Act
            _validCommand.Validate();

            // Assert      
           Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}

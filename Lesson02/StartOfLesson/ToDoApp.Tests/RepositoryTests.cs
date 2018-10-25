using System;
using ToDoApp.Models;
using ToDoApp.Services;
using Xunit;

namespace ToDoApp.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public void Test1()
        {
            // Assemble
            var repo = new Repository();
            var status = new Status
            {
                Id = 2,
                Value = "Value"
            };
            var todo = new ToDo
            {
                Id = 9,
                Title = "Test Title",
                Description = "Test Desc",
                Status = status
            };

            // Act
            Repository.ToDos.Add(todo);
            var result = Repository.ToDos.Find(x => x.Id == todo.Id);

            // Assert
            Assert.Contains(result, Repository.ToDos);
            Assert.Equal(todo, result);
        }
    }
}

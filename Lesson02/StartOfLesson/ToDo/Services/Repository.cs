using System.Collections.Generic;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class Repository
    {
        public static Dictionary<int, Status> Statuses = new Dictionary<int, Status>
        {
            { 1, new Status { Id = 1, Value = "Not Started" } },
            { 2, new Status { Id = 2, Value = "In Progress" } },
            { 3, new Status { Id = 3, Value = "Done" } }
        };

        public static List<ToDo> ToDos = new List<ToDo>
        {
            new ToDo
            {
                Id = 1,
                Title = "My First ToDo",
                Description = "Get the app working",
                Status = Statuses[2],
            },
            new ToDo
            {
                Id = 2,
                Title = "Add DateTime",
                Description = "Should track when the ToDo was created",
                Status = Statuses[1],
            },
            new ToDo
            {
                Id = 3,
                Title = "Add day-of-the-week TagHelper",
                Description = "Need an attribute we can use in our view that will pretty format the DateTime as a weekday when possible",
                Status = Statuses[1],
            },
            new ToDo
            {
                Id = 4,
                Title = "Add ViewComponent",
                Description = "Should track when the ToDo was created",
                Status = Statuses[1],
            }
        };
    }
}

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
            new ToDo { Id = 1, Title = "My First ToDo", Description = "Get the app working", Status = Statuses[2] }
        };
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        private static Dictionary<int, Status> statuses = new Dictionary<int, Status>
        {
            { 1, new Status { Id = 1, Value = "Not Started" } },
            { 2, new Status { Id = 2, Value = "In Progress" } },
            { 3, new Status { Id = 3, Value = "Done"} }
        };
        private static List<ToDo> list = new List<ToDo>
        {
            new ToDo {
                Id = 1,
                Title = "My First ToDo",
                Description = "Get the app working",
                Status = statuses[2]
            }
        };
        public IActionResult Index()
        {
            return View(list);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int? statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("Error404");
                default:
                    return View();
            }
        }
    }
}
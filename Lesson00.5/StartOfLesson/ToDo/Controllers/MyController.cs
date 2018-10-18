using System;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            var englishMessage = hour < 12 ? "Good Morning" : "Good Afternoon";
            ViewBag.EnglishGreeting = englishMessage;
            var spanishMessage = hour < 12 ? "Buenos Días" : "Buenas Tardes";
            ViewData["SpanishGreeting"] = spanishMessage;
            var mandarinMessage = hour < 12 ? "早上好" : "下午好";
            return View("Greeting", mandarinMessage);
        }
    }
}
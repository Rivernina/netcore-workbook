using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

namespace ToDoApp.ViewComponents
{
    public class CardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(CardViewModel model)
        {
            return View(model);
        }
    }
}
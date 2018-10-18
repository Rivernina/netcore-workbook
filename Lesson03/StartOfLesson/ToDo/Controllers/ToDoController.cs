using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {

        // GET: ToDo
        public ActionResult Index()
        {
            return View(Repository.ToDos);
        }

        // GET: ToDo/Details/5
        public ActionResult Details(int id)
        {
            return View(Repository.GetToDo(id));
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDo toDo)
        {
            try
            {
                // TODO: Add insert logic here
                Repository.Add(toDo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repository.GetToDo(id));
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDo toDo)
        {
            try
            {
                // TODO: Add update logic here
                Repository.Update(id, toDo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Repository.GetToDo(id));
        }

        // POST: ToDo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ToDo collection)
        {
            try
            {
                // TODO: Add delete logic here
                Repository.DeleteToDo(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
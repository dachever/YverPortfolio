using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class ItemsController : Controller
    {
        // GET: /Items/Overview
        public IActionResult Overview()
        {
            // Create a sample item (you can later fetch from database)
            var item = new Item() { Id = 2, Name = "Keyboard" };
            return View(item);
        }

        // GET: /Items/Edit/2
        public IActionResult Edit(int id)
        {
            // Just return content for now (later you can return a view)
            return Content("Editing item with id = " + id);
        }
    }
}

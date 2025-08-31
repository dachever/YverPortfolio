using Microsoft.AspNetCore.Mvc;

namespace YourAppNamespace.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            // Always set ViewData to avoid null
            ViewData["Title"] = "My Projects";

            // If you want to show a list of project categories
            var projects = new List<string>
            {
                "Graphic Design",
                "Web Development",
                "Photography"
            };

            return View(projects);  // Pass data to the view
        }
    }
}

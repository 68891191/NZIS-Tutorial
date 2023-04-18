using Microsoft.AspNetCore.Mvc;

using WebApp.Models;

namespace WebApp.Controllers
{
    public class UniversityController : Controller
    {
        public IActionResult Index()
        {
            University waikatoUniversity = new()
            {
                Id = 1,
                QSRank = 331,
                Name = "The University of Waikato",
                Description = "The University of Waikato is committed to delivering a world-class education and research portfolio. With around 13,000 students and 1,500 staff, we offer a distinctive and rewarding university experience, while pursuing strong international links to advance knowledge.",
                Website = "https://www.waikato.ac.nz/",
                City = "Hamilton"
            };

            ViewData["University"] = waikatoUniversity;
            ViewBag.Univeristy = waikatoUniversity;

            return View();
        }
    }
}

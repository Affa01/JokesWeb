using JokesWeb.Models;
using JokesWebsite.Data;
using Microsoft.AspNetCore.Mvc;

namespace JokesWeb.Controllers {
   public class JokeController : Controller {
      private readonly ApplicationDbContext _context;

      public JokeController(ApplicationDbContext context) {
         _context = context;

      }

      public IActionResult Index() {
         IEnumerable<Joke> objJokesList = _context.Jokes;
         return View(objJokesList);
      }

      //GET
      public IActionResult Create() {
         return View();
      }

      // POST
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(Joke obj) {
         if (ModelState.IsValid) {
            // Here, you would typically save the joke to a database.
            // For simplicity, let's assume you have a JokeRepository.
            // JokeRepository.Save(joke);
            _context.Add(obj);
            _context.SaveChangesAsync();
            // Redirect to the index page or any other page after successful submission.
            return RedirectToAction("Index");
         }

         return View(obj);
      }

      //GET
      public IActionResult Editar() {
         return View();
      }

      //GET
      public IActionResult Eliminar() {
         return View();
      }
   }
}

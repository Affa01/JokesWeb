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
   }
}

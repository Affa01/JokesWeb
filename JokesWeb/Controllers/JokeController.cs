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

            _context.Add(obj);
            _context.SaveChangesAsync();
            TempData["success"] = "Joke created successfully";
            return RedirectToAction("Index");
         }

         return View(obj);
      }





      //GET
      public IActionResult Edit(int? id) {
         if (id == null || id == 0) { 
            return NotFound();
         }
         var JokefromDb = _context.Jokes.Find(id);
         //var JokefromDbFisrt = _context.Jokes.FirstOrDefault(j => j.Id == id);
         //var JokefromDbSingle = _context.Jokes.SingleOrDefault(j => j.Id == id);

         if (JokefromDb == null) { 
            return NotFound(); 
         }

         return View(JokefromDb);
      }

      // POST
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit(Joke obj) {
         if (ModelState.IsValid) {
            _context.Update(obj);
            _context.SaveChangesAsync();
            TempData["success"] = "Joke updated successfully";
            return RedirectToAction("Index");
         }

         return View(obj);
      }

      //GET
      public IActionResult Delete(int? id) {
         if (id == null || id == 0) {
            return NotFound();
         }
         var JokefromDb = _context.Jokes.Find(id);
         //var JokefromDbFisrt = _context.Jokes.FirstOrDefault(j => j.Id == id); outra maneira de ir buscar a Joke
         //var JokefromDbSingle = _context.Jokes.SingleOrDefault(j => j.Id == id); outra maneira de ir buscar a Joke

         if (JokefromDb == null) {
            return NotFound();
         }

         return View(JokefromDb);
      }

      // POST
      [HttpPost,ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeletePOST(int? id) {

         var obj = _context.Jokes.Find(id);

         if (obj == null) {
            return NotFound();   
         }

         if (ModelState.IsValid) {
            _context.Remove(obj);
            _context.SaveChangesAsync();
            TempData["success"] = "Joke deleted successfully";
            return RedirectToAction("Index");
         }

         return View(obj);
      }
   }
}

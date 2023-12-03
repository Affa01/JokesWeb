using JokesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace JokesWebsite.Data {
   public class ApplicationDbContext : DbContext {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

      }

      public DbSet<Joke> Jokes{ get; set; }
   }
}

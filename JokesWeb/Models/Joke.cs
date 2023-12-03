using System.ComponentModel.DataAnnotations;

namespace JokesWeb.Models {
   public class Joke {
      [Key]
      public int Id { get; set; }
      [Required]
      public string? JokeQuestion { get; set; }
      [Required]
      public string? JokeAnswer { get; set; }
   }
}

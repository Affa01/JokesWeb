using System.ComponentModel.DataAnnotations;

namespace JokesWeb.Models {
   public class Joke {
      [Key]
      public int Id { get; set; }
      [Required]
      public string JokesQuestion { get; set; }
      [Required]
      public string JokesAnswer { get; set; }
   }
}

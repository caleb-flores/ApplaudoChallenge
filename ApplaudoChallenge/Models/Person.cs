using System.ComponentModel.DataAnnotations;

namespace ApplaudoChallenge.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool Disabled { get; set; }
    }
}

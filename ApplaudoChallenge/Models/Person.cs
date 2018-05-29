using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ApplaudoChallenge.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [JsonProperty("first")]
        public string FirstName { get; set; }
        [Required]
        [JsonProperty("last")]
        public string LastName { get; set; }
        public bool Disabled { get; set; }
    }
}

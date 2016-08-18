using System.ComponentModel.DataAnnotations;

namespace CustomRouteAttributes.Models
{
    public class Thing
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

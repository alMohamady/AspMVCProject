using System.ComponentModel.DataAnnotations;

namespace AspMVCProject.Models
{
    public class TheClass
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string className { get; set; }

        public string? teacher { get; set; }

        public virtual List<TheClassStudent> students { get; set; } = new List<TheClassStudent>();
    }
}

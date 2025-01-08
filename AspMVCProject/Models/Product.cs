using System.ComponentModel.DataAnnotations;

namespace AspMVCProject.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required, MaxLength(50)]
        public string? name { get; set; }

        public decimal price { get; set; }

        public DateTime createdDate { get; set; }
    }
}

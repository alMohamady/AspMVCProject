using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspMVCProject.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required, MaxLength(50)]
        [DisplayName("Product name")]
        public string? name { get; set; }

        [DisplayName("Product price")]
        public decimal price { get; set; }

        [DisplayName("Create date")]
        public DateTime createdDate { get; set; } = DateTime.Now;
    }
}

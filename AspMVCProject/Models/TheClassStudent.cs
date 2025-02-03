using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspMVCProject.Models
{
    public class TheClassStudent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string? phone {  get; set; }

        [ForeignKey("theClass")]
        public int theClassId { get; set; }

        public TheClass theClass { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace HipermarketApp.Models
{
    public class Zone 
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Location>? Locations { get; set; }
    }
}

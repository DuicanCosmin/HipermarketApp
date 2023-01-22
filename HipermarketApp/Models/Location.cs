using System.ComponentModel.DataAnnotations;

namespace HipermarketApp.Models
{
    public class Location
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public virtual int ZoneID { get; set; }

        public virtual Zone Zone { get; set; }

        public virtual ICollection<ProductsOnLocation> LocationProducts {get;set;}
    }
}

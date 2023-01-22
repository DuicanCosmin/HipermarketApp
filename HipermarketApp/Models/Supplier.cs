using System.ComponentModel.DataAnnotations;

namespace HipermarketApp.Models
{
    public class Supplier
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string SupplierName { get; set; }
        [Required]
        public string Address { get; set; }

        [EmailAddress, Required]
        public string Contact { get; set; }

        public virtual ICollection<Product> Products{get;set;}
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HipermarketApp.Models
{
    public class Product
    {   
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Precision(14, 2)]
        public decimal SellPrice { get; set; }

        
        public long SafetyStock { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Supplier>Suppliers { get; set; }

        public virtual ICollection<ProductsOnLocation> LocationProducts { get; set; }
    }
}

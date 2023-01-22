using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HipermarketApp.Models
{
    public class ProductsSupplierDetails
    {
        [Key, Column(Order = 0)]
        public int  ProductID { get; set; }

        public virtual Product Product { get; set; }    

        [Key, Column(Order = 1)]
        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }

        [Required]
        public decimal PurchasePrice { get; set; }

        [Required]
        public int  LeadTime { get; set; }

    }
}

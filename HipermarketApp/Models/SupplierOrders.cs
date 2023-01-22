using System.ComponentModel.DataAnnotations;

namespace HipermarketApp.Models
{
    public class SupplierOrders
    {
        [Key]
        public int ID { get; set; }

        public string OrderNumber { get; set; }
        [Required]
        public int ProductID { get; set; }


        public virtual Product Product { get; set; }

        [Required]
        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }

        [Required]
        public int OrderedQty { get; set; }

        [Required]
        public DateTime DeliveryDate {get;set;}
    }
}

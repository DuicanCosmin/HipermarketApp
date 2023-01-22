using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HipermarketApp.Models
{
    public class ProductsOnLocation
    {
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }

        [Key, Column(Order = 1)]
        public int LocationId { get; set; }

        [Required]
        [Precision(14, 2)]
        public int Quantity { get; set; }

        public int MinQuantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Location Location { get; set; }

        


    }
}

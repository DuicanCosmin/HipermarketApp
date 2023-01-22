using System.ComponentModel.DataAnnotations;

namespace HipermarketApp.Models
{
    public class Category
    {   
        [Key]
        public int ID { get; set; }

        [Required,MaxLength(50)]
        public string CategoryName { get; set; }
    }
}

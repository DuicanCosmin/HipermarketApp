using HipermarketApp.Models;

namespace HipermarketApp.ViewModels
{
    public class ZoneVM : Zone
    {
        public virtual ICollection<Category> PossibleCategories { get; set; }

    }
}

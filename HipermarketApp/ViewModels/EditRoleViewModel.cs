using System.ComponentModel.DataAnnotations;

namespace HipermarketApp.ViewModels
{
    public class EditRoleViewModel
    {
        public string   ID { get; set; }
        
        [Required(ErrorMessage ="Role name is required")]
            public string RoleName { get; set; }

        public List<string> Users { get; set; } = new();
    }
}
  
using System.ComponentModel.DataAnnotations;

namespace HipermarketApp.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
    
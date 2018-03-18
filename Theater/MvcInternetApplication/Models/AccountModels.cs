using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcInternetApplication.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class LocalPasswordModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "ВведитеСтарыйПароль", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string OldPassword { get; set; }
        
        [StringLength(15, ErrorMessage = "ОшибкаВводаПароля")]
        [DataType(DataType.Password)]
        [Display(Name = "НовыйПароль", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ПовторитеПароль", ResourceType = typeof(App_LocalResources.GlobalRes))]
        [Compare("NewPassword", ErrorMessage = "ПаролиНеСовпадают")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Display (Name = "Имя", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Пароль", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string Password { get; set; }
        
        [Display(Name = "ЗапомнитьМеня", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Display(Name = "Имя", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string UserName { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Пароль", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "ПовторитеПароль", ResourceType = typeof(App_LocalResources.GlobalRes))]
        [Compare("Password", ErrorMessage = "ПаролиНеСовпадают")]
        public string ConfirmPassword { get; set; }
    }
}

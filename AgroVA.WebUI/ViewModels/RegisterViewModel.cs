using System.ComponentModel.DataAnnotations;

namespace AgroVA.WebUI.ViewModels;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    public string? Name { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    [Display(Name = "Confirm password")]
    public string? ConfirmPassword { get; set; }
}

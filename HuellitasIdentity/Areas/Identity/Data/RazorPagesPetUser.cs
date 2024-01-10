using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HuellitasIdentity.Areas.Identity.Data;

// Add profile data for application users by adding properties to the RazorPagesPetUser class
public class RazorPagesPetUser : IdentityUser
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
}


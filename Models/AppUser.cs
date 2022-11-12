using Microsoft.AspNetCore.Identity;
using SuperAdmin.Models.Shop;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace SuperAdmin.Models
{
    public class AppUser : IdentityUser
    {
        public string? level { get; set; }
        public Coupon? Coupon { get; set; }
    }
}

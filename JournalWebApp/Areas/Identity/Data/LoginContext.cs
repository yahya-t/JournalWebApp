using JournalWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JournalWebApp.Data;

public class LoginContext : IdentityDbContext<LoginUser>
{
    public LoginContext(DbContextOptions<LoginContext> options) : base(options) 
    {
    }

}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Domain.Models;

namespace PersonalCV.Data;

public class PersonalCVContext(DbContextOptions<PersonalCVContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<ContactMessage> ContactMessage { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var appUser = new IdentityUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = "jebaleali@gmail.com",
            EmailConfirmed = true,
            UserName = "jebaleali@gmail.com",
            NormalizedUserName = "JEBALEALI@GMAIL.COM",
            NormalizedEmail = "JEBALEALI@GMAIL.COM"
        };

        //set user password
        PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
        appUser.PasswordHash = ph.HashPassword(appUser, "alijebale");

        //seed user
        builder.Entity<IdentityUser>().HasData(appUser);

        base.OnModelCreating(builder);
    }
}

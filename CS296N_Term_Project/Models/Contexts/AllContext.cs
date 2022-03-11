using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N_Term_Project.Models.Contexts
{
    public class AllContext : IdentityDbContext<AppUser>
    {
        public AllContext(DbContextOptions<AllContext> options) : base(options) { }
        public DbSet<ImagePost> Image { get; set; }
        public DbSet<VideoPost> Video { get; set; }
        public DbSet<Comment> Comments { get; set; }

        private UserManager<AppUser> userManager;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { Id = "6e421fd4-184e-48ed-b0e6-3308fa4ffd94", UserName = "Test", NormalizedUserName = "TEST", PasswordHash = "AQAAAAEAACcQAAAAEFxcmHoCg810zcza/HOr07LoC9Z/Gs5lV06I3FMUJ3tfX52yMii9unV33aOkGnFFZA==", SecurityStamp = "LAPZU4RWHYADCUAU45PNE4X3RYZVPO2S", ConcurrencyStamp = "cd14427e-350a-4316-b67c-1e581905947e", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0 }
                );
            //TODO: Get AppUser into seeded posts
            AppUser temp = userManager.FindByIdAsync("6e421fd4-184e-48ed-b0e6-3308fa4ffd94").Result;

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ImagePost>().HasData(
                new ImagePost { PostId = 1, User = temp, PosterName = "Tester1", Title = "Test", Description = "This is a test", Likes = 0, Path = "https://media.discordapp.net/attachments/623342534860603394/934990260058873896/V2_33000x3000.png?width=905&height=905" },
                new ImagePost { PostId = 2, User = temp, PosterName = "Tester1", Title = "Test2", Description = "This is a test2", Likes = 0, Path = "https://media.discordapp.net/attachments/623342534860603394/934980542603075615/snap2020-02-02-20-44-10.png?width=1290&height=726" }
                );

            modelBuilder.Entity<VideoPost>().HasData(
                new ImagePost { PostId = 1, User = temp, PosterName = "Tester1", Title = "Test", Description = "This is a test", Likes = 0, Path = "test" },
                new ImagePost { PostId = 2, User = temp, PosterName = "Tester1", Title = "Test2", Description = "This is a test2", Likes = 0, Path = "test2" }
                );
        }
    }
}

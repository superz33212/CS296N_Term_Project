using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N_Term_Project.Models.Contexts
{
    public class AllContext : IdentityDbContext<AppUser>
    {
        public AllContext(DbContextOptions<AllContext> options) : base(options) { }
        public DbSet<ImagePost> Images { get; set; }
        public DbSet<VideoPost> Videos { get; set; }
        public DbSet<ImageComment> ImageComments { get; set; }
        public DbSet<VideoComment> VideoComments { get; set; }

        //private UserManager<AppUser> userManager;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppUser temp = new AppUser 
                { 
                    Id = "6e421fd4-184e-48ed-b0e6-3308fa4ffd94", 
                    UserName = "Test", 
                    NormalizedUserName = "TEST", 
                    PasswordHash = "AQAAAAEAACcQAAAAEFxcmHoCg810zcza/HOr07LoC9Z/Gs5lV06I3FMUJ3tfX52yMii9unV33aOkGnFFZA==", 
                    SecurityStamp = "LAPZU4RWHYADCUAU45PNE4X3RYZVPO2S", 
                    ConcurrencyStamp = "cd14427e-350a-4316-b67c-1e581905947e", 
                    PhoneNumberConfirmed = false, 
                    TwoFactorEnabled = false, 
                    LockoutEnabled = true, 
                    AccessFailedCount = 0,
                    ScreenName = "Test"
                };
            ImagePost tempPost = new ImagePost 
                { 
                    PostId = 1, 
                    UserId = "6e421fd4-184e-48ed-b0e6-3308fa4ffd94", 
                    PosterName = "Tester1", 
                    Title = "Test", 
                    Description = "This is a test", 
                    Likes = 0, 
                    Path = "MagicaVoxelImages/5.1.png"
            };
            
            modelBuilder.Entity<AppUser>().HasData(
                temp
                );
            //TODO: Get AppUser into seeded posts
            //AppUser temp = userManager.FindByIdAsync("6e421fd4-184e-48ed-b0e6-3308fa4ffd94").Result;

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ImagePost>().HasData(
                tempPost,
                new ImagePost 
                {   
                    PostId = 2, 
                    UserId = "6e421fd4-184e-48ed-b0e6-3308fa4ffd94", 
                    PosterName = "Tester1", 
                    Title = "Test2", 
                    Description = "This is a test2", 
                    Likes = 0, 
                    Path = "MagicaVoxelImages/Boat.png"
                },
                new ImagePost 
                { 
                    PostId = 3, 
                    UserId = "6e421fd4-184e-48ed-b0e6-3308fa4ffd94", 
                    PosterName = "Tester1", 
                    Title = "Test3", 
                    Description = "This is a with an uploaded image", 
                    Likes = 0, 
                    Path = "MagicaVoxelImages/Spiral_100000.png" }
                );

            modelBuilder.Entity<ImageComment>().HasData(
                new
                {
                    CommentId = 1,
                    CommenterId = temp.Id,
                    PostId = tempPost.PostId,
                    Description = "This is a test",
                    Likes = 0
                }
                );

            modelBuilder.Entity<VideoPost>().HasData(
                new VideoPost 
                { 
                    PostId = 1, 
                    UserId = "6e421fd4-184e-48ed-b0e6-3308fa4ffd94", 
                    PosterName = "Tester1", 
                    Title = "Test", 
                    Description = "This is a test", 
                    Likes = 0, 
                    Path = "test", 
                    ThumbPath = "MagicaVoxelImages/Spiral_100000.png"
                },
                new VideoPost 
                { 
                    PostId = 2, 
                    UserId = "6e421fd4-184e-48ed-b0e6-3308fa4ffd94", 
                    PosterName = "Tester1", 
                    Title = "Test2", 
                    Description = "This is a test2", 
                    Likes = 0, 
                    Path = "test2", 
                    ThumbPath = "MagicaVoxelImages/waterfall.png"
                }
                );

        }
    }
}

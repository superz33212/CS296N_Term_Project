using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N_Term_Project.Models.Contexts
{
    public class AllContext //: IdentityDbContext<AppUser>
    {
        //public AllContext(DbContextOptions<AllContext> options) : base(options) { }
        public DbSet<ImagePost> Image { get; set; }
        public DbSet<VideoPost> Video { get; set; }
        public DbSet<Comment> Comments { get; set; }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { Id = "6e421fd4-184e-48ed-b0e6-3308fa4ffd94", UserName = "Test", NormalizedUserName = "TEST", PasswordHash = "AQAAAAEAACcQAAAAEFxcmHoCg810zcza/HOr07LoC9Z/Gs5lV06I3FMUJ3tfX52yMii9unV33aOkGnFFZA==", SecurityStamp = "LAPZU4RWHYADCUAU45PNE4X3RYZVPO2S", ConcurrencyStamp = "cd14427e-350a-4316-b67c-1e581905947e", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0, Nickname = "Zach J.", LocalId = "1" }
                );
        }
        */
    }
}

using CS296N_Term_Project.Models.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N_Term_Project.Models.DataLayer
{
    public class PostRepo : IPostRepo
    {
        private AllContext db { get; set; }

        public PostRepo(AllContext ctx)
        {
            this.db = ctx;
        }

        private UserManager<AppUser> userManager;

        #region Insert, Update, Remove, Save ==========
        public void Insert(ImagePost obj)
        {
            this.db.Image.Add(obj);
        }

        public void Insert(VideoPost obj)
        {
            this.db.Video.Add(obj);
        }

        public void Insert(Comment obj)
        {
            this.db.Comments.Add(obj);
        }
        
        public void Update(ImagePost obj)
        {
            this.db.Image.Update(obj);
        }

        public void Update(VideoPost obj)
        {
            this.db.Video.Update(obj);
        }

        public void Update(Comment obj)
        {
            this.db.Comments.Update(obj);
        }

        public void Delete(ImagePost obj)
        {
            this.db.Image.Remove(obj);
        }

        public void Delete(VideoPost obj)
        {
            this.db.Video.Remove(obj);
        }

        public void Delete(Comment obj)
        {
            this.db.Comments.Remove(obj);
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
        #endregion ====================================

        #region Select By ID ==========================
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<AppUser> UserByIdAsync(string id)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            AppUser temp = userManager.FindByIdAsync(id).Result;
            return temp;
        }

        public async Task<ImagePost> SelectImagesByIdAsync(int id)
        {
            ImagePost temp = await db.Image.Where(s => s.PostId == id).FirstAsync<ImagePost>();
            return temp;
        }

        public async Task<VideoPost> SelectVideoByIdAsync(int id)
        {
            VideoPost temp = await db.Video.Where(s => s.PostId == id).FirstAsync<VideoPost>();
            return temp;
        }
        #endregion ====================================

        #region Select Large Groups ===================
        public async Task<IEnumerable<ImagePost>> SelectImagesAsync()
        {
            List<ImagePost> temp = await db.Image.ToListAsync<ImagePost>();
            return temp;
        }

        public async Task<IEnumerable<VideoPost>> SelectVideoAsync()
        {
            List<VideoPost> temp = await db.Video.ToListAsync<VideoPost>();
            return temp;
        }
        #endregion ====================================
    }
}

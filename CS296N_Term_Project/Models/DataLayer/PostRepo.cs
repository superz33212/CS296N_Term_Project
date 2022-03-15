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

        public IQueryable<ImagePost> Images
        {
            get
            {
                return this.db.Images.Include(r => r.Comments)
                                      .ThenInclude(r => r.Commenter);
            }
        }

        private UserManager<AppUser> userManager;

        #region Insert, Update, Remove, Save ==========
        public void Insert(ImagePost obj)
        {
            this.db.Images.Add(obj);
        }

        public void Insert(VideoPost obj)
        {
            this.db.Videos.Add(obj);
        }

        public void Insert(ImageComment obj)
        {
            this.db.ImageComments.Add(obj);
        }

        public void Insert(VideoComment obj)
        {
            this.db.VideoComments.Add(obj);
        }

        public void Update(ImagePost obj)
        {
            this.db.Images.Update(obj);
        }

        public void Update(VideoPost obj)
        {
            this.db.Videos.Update(obj);
        }

        public void Update(ImageComment obj)
        {
            this.db.ImageComments.Update(obj);
        }

        public void Update(VideoComment obj)
        {
            this.db.VideoComments.Update(obj);
        }

        public void Delete(ImagePost obj)
        {
            this.db.Images.Remove(obj);
        }

        public void Delete(VideoPost obj)
        {
            this.db.Videos.Remove(obj);
        }

        public void Delete(ImageComment obj)
        {
            this.db.ImageComments.Remove(obj);
        }

        public void Delete(VideoComment obj)
        {
            this.db.VideoComments.Remove(obj);
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
            ImagePost temp = await db.Images.Where(s => s.PostId == id).FirstAsync<ImagePost>();
            return temp;
        }

        public async Task<VideoPost> SelectVideoByIdAsync(int id)
        {
            VideoPost temp = await db.Videos.Where(s => s.PostId == id).FirstAsync<VideoPost>();
            return temp;
        }
        #endregion ====================================

        #region Search Bt Name ========================
        public async Task<IEnumerable<ImagePost>> SearchImagesAsync(string input)
        {
            List<ImagePost> temp = new List<ImagePost>();
            if (input != null && input != "")
            {
                temp = await db.Images.Where(s => s.Title.Contains(input)).ToListAsync<ImagePost>();
            }
            else
            {
                temp = await db.Images.Include(i => i.Comments).ToListAsync<ImagePost>();
            }
            return temp;
        }

        public async Task<IEnumerable<VideoPost>> SearchVideoAsync(string input)
        {
            List<VideoPost> temp = new List<VideoPost>();
            if (input != null && input != "")
            {
                temp = await db.Videos.Where(s => s.Title.Contains(input)).ToListAsync<VideoPost>();
            }
            else
            {
                temp = await db.Videos.Include(i => i.Comments).ToListAsync<VideoPost>();
            }
            return temp;
        }
        #endregion

        #region Select Large Groups ===================
        public async Task<IEnumerable<ImagePost>> SelectImagesAsync()
        {
            List<ImagePost> temp = await db.Images.Include(i => i.Comments).ToListAsync<ImagePost>();
            return temp;
        }

        public async Task<IEnumerable<VideoPost>> SelectVideoAsync()
        {
            List<VideoPost> temp = await db.Videos.Include(i => i.Comments).ToListAsync<VideoPost>();
            return temp;
        }
        #endregion ====================================
    }
}

using CS296N_Term_Project.Models.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N_Term_Project.Models.DataLayer
{
    /*
    public class FPostRepo : IPostRepo
    {
        private List<ImagePost> images = new List<ImagePost>();
        private List<VideoPost> videos = new List<VideoPost>();

        public IQueryable<ImagePost> Images
        {
            get
            {
                return (IQueryable<ImagePost>)this.images;
            }
        }

        public IQueryable<VideoPost> Videos
        {
            get
            {
                return (IQueryable<VideoPost>)this.videos;
            }
        }

        private List<ImageComment> ImageComments = new List<ImageComment>();
        private List<VideoComment> VideoComments = new List<VideoComment>();

        private UserManager<AppUser> userManager;
        
        #region Insert, Update, Remove, Save ==========
        public void Insert(ImagePost obj)
        {
            images.Add(obj);
        }

        public void Insert(VideoPost obj)
        {
            videos.Add(obj);
        }

        public void Insert(ImageComment obj)
        {
            ImageComments.Add(obj);
        }

        public void Insert(VideoComment obj)
        {
            VideoComments.Add(obj);
        }

        public void Update(ImagePost obj)
        {
            //ImagePost temp = Images.Where(s => s.PostId(obj.PostId)).First<ImagePost>();
            //this.db.Images.Update(obj);

        }

        public void Update(VideoPost obj)
        {
            //this.db.Videos.Update(obj);
        }

        public void Update(ImageComment obj)
        {
            //this.db.ImageComments.Update(obj);
        }

        public void Update(VideoComment obj)
        {
            //this.db.VideoComments.Update(obj);
        }

        public void Delete(ImagePost obj)
        {
            //this.db.Images.Remove(obj);
        }

        public void Delete(VideoPost obj)
        {
            //this.db.Videos.Remove(obj);
        }

        public void Delete(ImageComment obj)
        {
            //this.db.ImageComments.Remove(obj);
        }

        public void Delete(VideoComment obj)
        {
            //this.db.VideoComments.Remove(obj);
        }

        public async Task SaveAsync()
        {
            //await db.SaveChangesAsync();
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
            ImagePost temp = await Images.
                Where(s => s.PostId == id).
                FirstAsync<ImagePost>();
            return temp;
        }

        public async Task<VideoPost> SelectVideoByIdAsync(int id)
        {
            VideoPost temp = await Videos.
                Where(s => s.PostId == id).
                FirstAsync<VideoPost>();
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

        public async Task<IEnumerable<VideoPost>> SearchVideosAsync(string input)
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

        public async Task<IEnumerable<VideoPost>> SelectVideosAsync()
        {
            List<VideoPost> temp = await db.Videos.Include(i => i.Comments).ToListAsync<VideoPost>();
            return temp;
        }
        #endregion ====================================
        
    }*/
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N_Term_Project.Models.DataLayer
{
    public interface IPostRepo
    {
        public IQueryable<ImagePost> Images { get; }
        public IQueryable<VideoPost> Videos { get; }

        void Insert(ImagePost obj);
        void Insert(VideoPost obj);
        void Insert(ImageComment obj);
        void Insert(VideoComment obj);

        void Update(ImagePost obj);
        void Update(VideoPost obj);
        void Update(ImageComment obj);
        void Update(VideoComment obj);


        void Delete(ImagePost obj);
        void Delete(VideoPost obj);
        void Delete(ImageComment obj);
        void Delete(VideoComment obj);

        Task SaveAsync();



        Task<AppUser> UserByIdAsync(string id);

        Task<ImagePost> SelectImagesByIdAsync(int id);
        Task<VideoPost> SelectVideoByIdAsync(int id);

        Task<IEnumerable<ImagePost>> SearchImagesAsync(string input);
        Task<IEnumerable<VideoPost>> SearchVideosAsync(string input);

        Task<IEnumerable<ImagePost>> SelectImagesAsync();
        Task<IEnumerable<VideoPost>> SelectVideosAsync();
    }
}

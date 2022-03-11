using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N_Term_Project.Models.DataLayer
{
    public interface IPostRepo
    {
        void Insert(ImagePost obj);
        void Insert(VideoPost obj);
        void Insert(Comment obj);

        void Update(ImagePost obj);
        void Update(VideoPost obj);
        void Update(Comment obj);


        void Delete(ImagePost obj);
        void Delete(VideoPost obj);
        void Delete(Comment obj);

        Task SaveAsync();



        Task<AppUser> UserByIdAsync(string id);

        Task<ImagePost> SelectImagesByIdAsync(int id);
        Task<VideoPost> SelectVideoByIdAsync(int id);

        Task<IEnumerable<ImagePost>> SelectImagesAsync();
        Task<IEnumerable<VideoPost>> SelectVideoAsync();
    }
}

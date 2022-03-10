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

        void Update(ImagePost obj);
        void Update(VideoPost obj);

        void Delete(ImagePost obj);
        void Delete(VideoPost obj);

        Task SaveAsync();



        Task<IEnumerable<ImagePost>> SelectImagesAsync();
        Task<IEnumerable<VideoPost>> SelectVideoAsync();
    }
}

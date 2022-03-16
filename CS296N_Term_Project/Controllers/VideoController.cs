using CS296N_Term_Project.Models;
using CS296N_Term_Project.Models.DataLayer;
using CS296N_Term_Project.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N_Term_Project.Controllers
{
    public class VideoController : Controller
    {
        private IPostRepo repo;

        private UserManager<AppUser> userManager;

        public VideoController(IPostRepo ctx, UserManager<AppUser> u)
        {
            repo = ctx;
            this.userManager = u;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.VideoPosts = await repo.SelectVideosAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SingleVideo(int id)
        {
            ViewBag.VideoPost = await repo.SelectVideoByIdAsync(id);
            CommentVM temp = new CommentVM();
            return View(temp);
        }

        [HttpPost]
        [Authorize]
        //TODO: Fix adding comments and loading them
        public async Task<IActionResult> SingleVideo(CommentVM comment)
        {
            var user = userManager.GetUserAsync(User).Result;
            VideoComment temp = new VideoComment();
            temp.Description = comment.Description;
            //temp.Post = await repo.SelectImagesByIdAsync(comment.PostId);
            temp.Commenter = user;

            var post = (from p in repo.Videos
                        where p.PostId == comment.PostId
                        select p).First<VideoPost>();
            post.AddComment(temp);
            //repo.Insert(temp);
            await repo.SaveAsync();
            return RedirectToAction("SingleVideo", comment.PostId);
            //return View("SingleImage", comment.imagePost.PostId);
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            string search = "";
            ViewBag.VideoPosts = await repo.SearchVideosAsync(search);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string search = "")
        {
            ViewBag.VideoPosts = await repo.SearchVideosAsync(search);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //=============================================================================================================================

        private readonly long _fileSizeLimit = 2097162; // 2,097,162
        private readonly string[] _permittedExtensions = { ".mp4", ".mov", ".avi", ".wmv" };
        private readonly string _targetFilePath = Path.GetFullPath(@"wwwroot\MagicaVoxelVideos");
        //HttpContext.Current.Server.MapPath(@"~\wwwroot\MagicaVoxelImages");
        public string Result { get; private set; }
        [Authorize]
        [HttpGet]
        public IActionResult Upload()
        {
            NewPostVM model = new NewPostVM();
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Upload(NewPostVM newPost)
        {

            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return View();
            }

            var formFileContent =
                await FileHelpers.ProcessFormFile<BufferedSingleFileUploadPhysical>(
                    newPost.Image.FormFile, ModelState, _permittedExtensions,
                    _fileSizeLimit);

            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";
                return View();
            }

            // For the file name of the uploaded file stored
            // server-side, use Path.GetRandomFileName to generate a safe
            // random file name.
            var trustedFileNameForFileStorage = Path.GetRandomFileName();
            var filePath = Path.Combine(
                _targetFilePath, trustedFileNameForFileStorage);

            // **WARNING!**
            // In the following example, the file is saved without
            // scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API
            // is used on the file before making the file available
            // for download or for use by other systems. 
            // For more information, see the topic that accompanies 
            // this sample.

            using (var fileStream = System.IO.File.Create(filePath))
            {
                await fileStream.WriteAsync(formFileContent);
                string[] splitPath = fileStream.Name.Split("\\");
                newPost.videoPost.Path = "/MagicaVoxelImages/" + splitPath[splitPath.Length - 1];
                // To work directly with a FormFile, use the following
                // instead:
                //await FileUpload.FormFile.CopyToAsync(fileStream);
            }

            //Add stuff to DB --fileStream
            var user = userManager.GetUserAsync(User).Result;
            newPost.videoPost.UserId = user.Id;
            newPost.videoPost.PosterName = user.ScreenName;
            newPost.videoPost.Likes = 0;
            repo.Insert(newPost.videoPost);
            await repo.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
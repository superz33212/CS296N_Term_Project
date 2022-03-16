using CS296N_Term_Project.Models;
using CS296N_Term_Project.Models.DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using CS296N_Term_Project.Models.ViewModels;

namespace CS296N_Term_Project.Controllers
{
    public class ImageController : Controller
    {
        private IPostRepo repo;

        private UserManager<AppUser> userManager;

        public ImageController(IPostRepo ctx, UserManager<AppUser> u)
        {
            repo = ctx;
            this.userManager = u;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.ImagePosts = await repo.SelectImagesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SingleImage(int id)
        {
            ViewBag.ImagePost = await repo.SelectImagesByIdAsync(id);
            CommentVM temp = new CommentVM();
            //temp.PostId = id;
            return View(temp);
        }

        [HttpPost]
        [Authorize]
        //TODO: Fix adding comments and loading them
        public async Task<IActionResult> SingleImage(CommentVM comment)
        {
            var user = userManager.GetUserAsync(User).Result;
            ImageComment temp = new ImageComment();
            temp.Description = comment.Description;
            //temp.Post = await repo.SelectImagesByIdAsync(comment.PostId);
            temp.Commenter = user;

            var post = (from p in repo.Images
                        where p.PostId == comment.PostId
                        select p).First<ImagePost>();
            post.AddComment(temp);
            //repo.Insert(temp);
            await repo.SaveAsync();
            return RedirectToAction("SingleImage", comment.PostId);
            //return View("SingleImage", comment.imagePost.PostId);
        }

        [HttpGet]
        public async Task<IActionResult> ImageUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageUpload(ImagePost newPost)
        {
            var user = userManager.GetUserAsync(User).Result;
            newPost.UserId = user.Id;
            newPost.PosterName = user.ScreenName;
            newPost.Likes = 0;
            //repo.Insert(newPost);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            string search = "";
            ViewBag.ImagePosts = await repo.SearchImagesAsync(search);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string search = "")
        {
            ViewBag.ImagePosts = await repo.SearchImagesAsync(search);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //=============================================================================================================================

        private readonly long _fileSizeLimit = 2097162; // 2,097,162
        private readonly string[] _permittedExtensions = { ".png", ".jpg", ".jpeg", ".gif" };
        private readonly string _targetFilePath = Path.GetFullPath(@"wwwroot\MagicaVoxelImages");
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
                newPost.imagePost.Path = "/MagicaVoxelImages/" + splitPath[splitPath.Length-1];
                // To work directly with a FormFile, use the following
                // instead:
                //await FileUpload.FormFile.CopyToAsync(fileStream);
            }

            //Add stuff to DB --fileStream
            var user = userManager.GetUserAsync(User).Result;
            newPost.imagePost.UserId = user.Id;
            newPost.imagePost.PosterName = user.ScreenName;
            newPost.imagePost.Likes = 0;
            repo.Insert(newPost.imagePost);
            await repo.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}

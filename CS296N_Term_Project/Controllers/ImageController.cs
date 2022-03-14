using CS296N_Term_Project.Models;
using CS296N_Term_Project.Models.DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

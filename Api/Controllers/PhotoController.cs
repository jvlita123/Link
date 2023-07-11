using Microsoft.AspNetCore.Mvc;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Service.Models;
using Service.Services;
using System.Web;
using Data.Repositories;

namespace Api.Controllers
{
    public class PhotoController : Controller
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
        private PhotoService _photoService;
        private UserService _userService;
        private AccountService _accountService;
        public PhotoController(PhotoService photoService, UserService userService, Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment, AccountService accountService)
        {
            _photoService = photoService;
            _userService = userService;
            Environment = _environment;
            _accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }

        /*[Route("Create")]
        [HttpPost]
        public ActionResult Create(PhotoViewModel model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];

            int i = _photoService.UploadImageInDataBase(file, model);
            if (i == 1)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }*/
        [HttpPost]
        public IActionResult Index(List<IFormFile> postedFiles, PhotoViewModel model)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            User? user = _userService.GetByAccId(account.Id);
            int userId = _userService.GetUserIdByAccountId(user.Id);
            bool isProfile = _photoService.CheckForUser(userId);

            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                isProfile = _photoService.CheckForUser(userId);
                string fileName = Path.GetFileName(postedFile.FileName);
                var photo = new Photo
                {
                    Path = fileName,
                    Description = model.Description,
                    UserId = userId,
                    Date = DateTime.Now,
                    IsProfilePicture = isProfile

                };
                _photoService.Add(photo);

            }
            
            return View();
        }
    }
}

using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApplication.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoSharingDB db = new PhotoSharingDB();

        // GET: Photo
        public ActionResult Index()
        {
            return View(db.Photos.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Photo photo = db.Photos.Find(id);

            if (photo == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Details", photo);
            }
        }

        public ActionResult DisplayPhoto(int id)
        {
            Photo photo = db.Photos.Find(id);
            return File(photo.PhotoFile, photo.ImageMimeType);
        }
    }
}
using OperasWebSite.Models;
using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApplication.Controllers
{
    [ValueReporter]
    public class PhotoController : Controller
    {
        private PhotoSharingDB db = new PhotoSharingDB();

        // GET: Photo
        //[SimpleActionFilter]
        public ActionResult Index()
        {
            var res = db.Photos.ToList();

            return View(res);
        }

        public ActionResult Display(int id)
        {
            Photo photo = db.Photos.Find(id);

            if (photo == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Display", photo);
            }
        }

        public ActionResult GetPhotoByTitle(string title)
        {
            Photo photo = db.Photos.FirstOrDefault(p => p.Title == title);
            if (photo != null)
            {
                return View("Details", photo);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult DisplayPhoto(int id)
        {
            Photo photo = db.Photos.Find(id);

            return File(photo.PhotoFile, photo.ImageMimeType);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Photo photo = new Photo();

            photo.CreatedDate = DateTime.Today;

            return View("Create", photo);
        }

        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Today;

            if (!ModelState.IsValid)
            {
                return View("Create", photo);
            }
            else
            {
                if(image != null)
                {
                    photo.ImageMimeType = image.ContentType;

                    photo.PhotoFile = new byte[image.ContentLength];

                    image.InputStream.Read(photo.PhotoFile,0,image.ContentLength);
                }

                db.Photos.Add(photo);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Photo photo = db.Photos.Find(id);

            if(photo == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Delete", photo);
            }
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);

            db.Photos.Remove(photo);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {
            Photo photo = db.Photos.Find(id);

            if(photo != null)
            {
                return File(photo.PhotoFile, photo.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
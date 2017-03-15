using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApplication.Controllers
{
    public class CommentsController : Controller
    {
        ICommentRepository commentRepository = new CommentRepository();

        // GET: Comments
        public ActionResult Index(int PhotoID)
        {
            ICollection<Comment> comments = commentRepository.GetComments(PhotoID);

            return View("Index", comments);
        }
    }
}
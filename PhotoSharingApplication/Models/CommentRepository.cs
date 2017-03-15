using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class CommentRepository : ICommentRepository
    {
        public PhotoSharingDB context;

        public CommentRepository()
        {
            context = new PhotoSharingDB();
        }

        public ICollection<Comment> GetComments(int PhotoID)
        {
            return context.Photos.Find(PhotoID).Comments.ToList();
        }
    }
}
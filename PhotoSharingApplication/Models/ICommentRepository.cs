using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharingApplication.Models
{
    public interface ICommentRepository
    {
        ICollection<Comment> GetComments(int PhotoID);
    }
}

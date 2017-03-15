using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class PhotoSharingInitializer : DropCreateDatabaseAlways<PhotoSharingContext>
    {
        protected override void Seed(PhotoSharingContext context)
        {
            List<Photo> photos = new List<Photo>()
            {
                new Photo
                {
                    Title="Test Photo",
                    Description = "Some Description",
                    UserName = "NaokiSato",
                    PhotoFile = getFileBytes
                }
            };
        }
    }
}
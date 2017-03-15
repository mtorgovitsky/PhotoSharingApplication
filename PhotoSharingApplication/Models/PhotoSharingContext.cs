using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class PhotoSharingDB : DbContext
    {
        public PhotoSharingDB()
            : base("name=PhotoSharingDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<PhotoSharingDB>(new PhotoSharingInitializer());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
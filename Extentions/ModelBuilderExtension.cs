using Assignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment3.Extentions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Seed Admin Account
            modelBuilder.Entity<AppUser>().HasData(
                    new AppUser
                    {
                        ID = 1,
                        Address = "HCM",
                        Email = "admin@gmail.com",
                        FullName = "admin",
                        Password = "123456"
                    }
                );
            #endregion

            #region Seed Category Data
            modelBuilder.Entity<PostCategory>().HasData(
                    new PostCategory
                    {
                        ID = 1,
                        CategoryName = "Education",
                        Description = "Education..."
                    },
                    new PostCategory
                    {
                        ID = 2,
                        CategoryName = "Healthcare",
                        Description = "Healthcare..."
                    },
                    new PostCategory
                    {
                        ID = 3,
                        CategoryName = "Science",
                        Description = "Science..."
                    },
                    new PostCategory
                    {
                        ID = 4,
                        CategoryName = "Technology",
                        Description = "Technology..."
                    }
                );
            #endregion

            #region Seed Initial Post Data
            modelBuilder.Entity<Post>().HasData(
                    new Post
                    {
                        ID = 1,
                        AuthorID = 1,
                        CategoryID = 4,
                        PublishStatus = Status.Published,
                        Title = "OOP Concepts in C#",
                    },
                    new Post
                    {
                        ID = 2,
                        AuthorID = 1,
                        CategoryID = 2,
                        PublishStatus = Status.Published,
                        Title = "50 Good Dishes For Breakfast",
                    },
                    new Post
                    {
                        ID = 3,
                        AuthorID = 1,
                        CategoryID = 3,
                        PublishStatus = Status.Published,
                        Title = "NASA And The Great Scientific Work",
                    },
                    new Post
                    {
                        ID = 4,
                        AuthorID = 1,
                        CategoryID = 1,
                        PublishStatus = Status.Published,
                        Title = "The Story Of Studying Abroad",
                    }
                );
            #endregion
        }
    }
}

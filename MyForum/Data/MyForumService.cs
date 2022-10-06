using MyForum.Data.MyForum;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyForum.Data
{
    public class MyForumService
    {
        private readonly ForumContext _context;
        public MyForumService(ForumContext context)
        {
            _context = context;
        }

        //Fetch posts that are created by the current user
        public async Task<List<Posts>>
            GetAllPostsAsync()
        {
            // Get Posts
            return await _context.Posts
                 // Use AsNoTracking to disable EF change tracking
                 // Use ToListAsync to avoid blocking a thread
                 .AsNoTracking().ToListAsync();
        }

        //Fetch posts that are created by the current user
        public async Task<List<Posts>>
            GetPostsAsync(string strCurrentUser)
        {
            // Get Posts
            return await _context.Posts
                 // Only get entries for the current logged in user
                 .Where(x => x.UserName == strCurrentUser)
                 // Use AsNoTracking to disable EF change tracking
                 // Use ToListAsync to avoid blocking a thread
                 .AsNoTracking().ToListAsync();
        }
        //Fetch posts that are created by other people
        public async Task<List<Posts>>
            GetOtherPostsAsync(string strCurrentUser)
        {
            // Get Posts
            return await _context.Posts
                 // Only get entries for the current logged in user
                 .Where(x => x.UserName != strCurrentUser)
                 // Use AsNoTracking to disable EF change tracking
                 // Use ToListAsync to avoid blocking a thread
                 .AsNoTracking().ToListAsync();
        }
        //Create a post
        public Task<Posts>
         CreatePostAsync(Posts objPosts)
        {
            _context.Posts.Add(objPosts);
            _context.SaveChanges();
            return Task.FromResult(objPosts);
        }
        //Edit a post
        public Task<bool>
            UpdatePostsAsync(Posts objPosts)
        {
            var ExistingPosts =
                _context.Posts
                .Where(x => x.Pid == objPosts.Pid)
                .FirstOrDefault();
            if (ExistingPosts != null)
            {
                ExistingPosts.Date =
                    objPosts.Date;
                ExistingPosts.Title =
                    objPosts.Title;
                ExistingPosts.Content =
                    objPosts.Content;

                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
        public Task<bool>
        DeletePostAsync(Posts objPosts)
        {
            var ExistingPosts =
                _context.Posts
                .Where(x => x.Pid == objPosts.Pid)
                .FirstOrDefault();
            if (ExistingPosts != null)
            {
                _context.Posts.Remove(ExistingPosts);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }



    }

}
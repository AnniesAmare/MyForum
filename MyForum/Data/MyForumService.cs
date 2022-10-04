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


        /* Function to get all posts
                public async Task<List<Posts>>
                    GetPostsAsync2()
                {
                    // Get Posts
                    return await _context.Posts
                         // Use AsNoTracking to disable EF change tracking
                         // Use ToListAsync to avoid blocking a thread
                         .AsNoTracking().ToListAsync();
                }
        */
    }
}
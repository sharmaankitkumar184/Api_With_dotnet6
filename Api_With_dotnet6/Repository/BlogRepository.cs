using Api_With_dotnet6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_With_dotnet6.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DatabaseContext _context;
        public BlogRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Blog> AddBlog(Blog blog)
        {
            var result = _context.Add(blog);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<Blog>> DeleteBlog(int Id)
        {
            var blog = await _context.Blogs.FindAsync(Id);

            if (blog == null) throw new Exception($"Invalid Product Id {blog?.Id}"); ;
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return (await _context.Blogs.ToListAsync());
        }

        public async Task<IEnumerable<Blog>> GetAllBlog()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlog(int Id)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == Id);
            if (blog == null)
                throw new Exception("Product not found");
            return blog;
        }

        public async Task<Blog> UpdateBlog(Blog blogData)
        {
             if (blogData == null || blogData.Id == 0)
                throw new Exception("Bad Request");

            var blog = await _context.Blogs.FindAsync(blogData.Id);
            if (blog == null)
                throw new Exception("Blog Not Found");

            blog.AuthorName = blogData.AuthorName;
            blog.AuthorAvatar = blogData.AuthorAvatar;
            blog.Blogtitle = blogData.Blogtitle;
            blog.Description = blogData.Description;
            blog.AssetType = blogData.AssetType;
            blog.ThumbnailText = blogData.ThumbnailText;
            blog.CreatedAt = blogData.CreatedAt;
            blog.UpdatedAt = blogData.UpdatedAt;
            blog.ImageUrl = blogData.ImageUrl;

            await _context.SaveChangesAsync();
            return (blog);
        }
    }
}

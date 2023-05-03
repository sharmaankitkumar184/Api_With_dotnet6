using Api_With_dotnet6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Api_With_dotnet6.Repository
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllBlog();
        Task<Blog> GetBlog(int Id);
        Task<Blog> AddBlog(Blog blog);
        Task<Blog> UpdateBlog(Blog blogData);
        Task<List<Blog>> DeleteBlog(int Id);
    }
}

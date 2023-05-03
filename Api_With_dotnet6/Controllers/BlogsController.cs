using Api_With_dotnet6.Models;
using Api_With_dotnet6.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_With_dotnet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogrepo;

        public BlogsController(IBlogRepository blogrepo)
        {
            _blogrepo = blogrepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> Get()
        {
            try
            {
                return Ok(await _blogrepo.GetAllBlog());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> Get(int id)
        {
            try
            {
                var result = await _blogrepo.GetBlog(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost]
        public async Task<ActionResult<List<Blog>>> Post(Blog blog)
        {
            try
            {
                if (blog == null)
                    return BadRequest();

                var createdBlog = await _blogrepo.AddBlog(blog);

                return Ok(createdBlog);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Blog>> Put(Blog blogData)
        {
            try
            {
                var blogToUpdate = await _blogrepo.GetBlog(blogData.Id);

                if (blogToUpdate == null)
                    return NotFound($"Blog with Id = {blogData.Id} not found");

                return await _blogrepo.UpdateBlog(blogData);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Blog>>> Delete(int id)
        {
            try
            {
                var blogToDelete = await _blogrepo.GetBlog(id);

                if (blogToDelete == null)
                {
                    return NotFound($"Blog with Id = {id} not found");
                }

                return await _blogrepo.DeleteBlog(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

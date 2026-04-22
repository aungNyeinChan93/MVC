using Microsoft.EntityFrameworkCore;
using SuperMarket.Data;
using SuperMarket.Dtos.Posts;
using SuperMarket.Models;

namespace SuperMarket.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _context;

        public PostService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            var posts = await _context.Posts.AsNoTracking().Include(p => p.Category).ToListAsync();
            return posts;
        }

        public async Task<Post?> GetOneAsync(int id)
        {
            var post = await _context.Posts
                .AsNoTracking()
                .Include(p => p.Category)
                .Where(p => p.PostId == id)
                .FirstOrDefaultAsync();
            return post;
        }

        public async Task<Post?> CreateAsync(CreatePostDto createPostDto)
        {
            if (createPostDto is null)
            {
                return default!;
            }

            Post newPost = new Post
            {
                Name = createPostDto.Name,
                Description = createPostDto.Description,
                CategoryId = createPostDto.CategoryId,
            };
            await _context.Posts.AddAsync(newPost);
            var result = await _context.SaveChangesAsync();
            return result >= 1 ? newPost : default!;
        }

        public async Task<bool> UpdateAsync(int id, CreatePostDto createPostDto)
        {
            if (createPostDto is null)
            {
                return false;
            }
            var existPost = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(p => p.PostId == id);
            if (existPost is null)
            {
                return false;
            }
            existPost.Name = createPostDto.Name;
            existPost.Description = createPostDto.Description;
            existPost.CategoryId = createPostDto.CategoryId;

            _context.Entry(existPost).State = EntityState.Modified;
            var res = await _context.SaveChangesAsync();
            return res >= 1 ? true : false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existPost = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(p => p.PostId == id);
            if (existPost is null)
            {
                return false;
            }
            _context.Remove(existPost);
            _context.Entry(existPost).State = EntityState.Deleted;
            var res = await _context.SaveChangesAsync();
            return res >= 1 ? true : false;

        }
    }
}

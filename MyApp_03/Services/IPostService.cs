using SuperMarket.Dtos.Posts;
using SuperMarket.Models;

namespace SuperMarket.Services
{
    public interface IPostService
    {
        Task<Post?> CreateAsync(CreatePostDto createPostDto);
        Task<bool> DeleteAsync(int id);
        Task<List<Post>> GetAllAsync();
        Task<Post?> GetOneAsync(int id);
        Task<bool> UpdateAsync(int id, CreatePostDto createPostDto);
    }
}
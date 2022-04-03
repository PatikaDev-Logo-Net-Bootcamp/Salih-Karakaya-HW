using First.App.Business.DTOs;
using First.App.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First.App.Business.Abstract
{
    public interface IPostService
    {
        Task<List<PostDto>> FetchAllPosts();

        void AddPost(Post post);

        void AddAllPosts(List<Post> posts);

        List<Post> GetAllPosts();
    }
}

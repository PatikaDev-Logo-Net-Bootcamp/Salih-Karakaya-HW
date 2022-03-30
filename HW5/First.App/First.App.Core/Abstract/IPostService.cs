using First.App.Domain.Entities;
using System.Collections.Generic;

namespace First.App.Business.Abstract
{
    public interface IPostService
    {
        List<Post> GetAllPosts();
        void AddPost(Post post);
    }
}

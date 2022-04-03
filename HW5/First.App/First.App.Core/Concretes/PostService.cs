using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.App.Business.Concretes
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPostFetcherService _postFetcherService;
        public PostService(
            IRepository<Post> repository,
            IUnitOfWork unitOfWork,
            IPostFetcherService postFetcherService)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this._postFetcherService = postFetcherService;
        }

        public async Task<List<PostDto>> FetchAllPosts()
        {
            return await _postFetcherService.Fetch();
        }

        public void AddPost(Post post)
        {
            repository.Add(post);
            unitOfWork.Commit();
        }

        public void AddAllPosts(List<Post> posts)
        {
            posts.ForEach(AddPost);
        }

        public List<Post> GetAllPosts()
        {
            return repository.Get().ToList();
        }
    }
}

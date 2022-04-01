using First.App.Business.Abstract;
using First.App.Business.DTOs;
using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First.App.Business.Concretes
{
    public class PostFetcherService : IPostFetcherService
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com";

        public async Task<List<PostDto>> Fetch()
        {
            return await BaseUrl
                .AppendPathSegment("posts")
                .GetJsonAsync<List<PostDto>>();
        }
    }
}

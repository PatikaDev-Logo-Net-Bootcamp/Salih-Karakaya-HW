using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.Domain.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebSiteStatusCheck
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPostService _postService;
        public Worker(ILogger<Worker> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _postService.AddAllPosts(
                    ToEntity(await _postService.FetchAllPosts())
                );
                _logger.LogInformation("Posts fetched, database updated");
                await Task.Delay(5000, stoppingToken);
            }
        }

        private static List<Post> ToEntity(List<PostDto> postDtos)
        {
            return postDtos.Select(post => new Post
            {
                Body = post.Body,
                Title = post.Title,
                UserId = post.UserId
            }).ToList();
        }

    }
}

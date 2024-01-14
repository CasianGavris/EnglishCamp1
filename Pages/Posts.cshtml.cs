using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages
{
    public class PostsModel : PageModel
    {
        private readonly ILogger<PostsModel> _logger;
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ITagRepository tagRepository;

        public List<BlogPost> Blogs { get; set; }
        public List<Tag> Tags { get; set; }

        public PostsModel(ILogger<PostsModel> logger,
            IBlogPostRepository blogPostRepository,
            ITagRepository tagRepository)
        {
            _logger = logger;
            this.blogPostRepository = blogPostRepository;
            this.tagRepository = tagRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Blogs = (await blogPostRepository.GetAllAsync()).ToList();
            Tags = (await tagRepository.GetAllAsync()).ToList();

            return Page();
        }
    }
}
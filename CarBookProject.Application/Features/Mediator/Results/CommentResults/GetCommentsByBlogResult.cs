using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentsByBlogResult
    {
        public int CommentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ImageUrl { get; set; }
        public int BlogId { get; set; }
    }
}

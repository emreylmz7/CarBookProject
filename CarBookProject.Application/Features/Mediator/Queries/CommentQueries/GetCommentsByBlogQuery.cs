using CarBookProject.Application.Features.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentsByBlogQuery : IRequest<List<GetCommentsByBlogResult>>
    {
        public int Id { get; set; }

        public GetCommentsByBlogQuery(int id)
        {
            Id = id;
        }
    }
}

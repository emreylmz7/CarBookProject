using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Quaries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public int Id { get; set; }

        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }
    }
}

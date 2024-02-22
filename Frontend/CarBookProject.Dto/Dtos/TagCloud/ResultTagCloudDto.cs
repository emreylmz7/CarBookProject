using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.Dtos.TagCloud
{
    public class ResultTagCloudDto
    {
        public int TagCloudId { get; set; }
        public string? Title { get; set; }
        public int BlogId { get; set; }
    }
}

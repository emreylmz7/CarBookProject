using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Commands.DropOffLocationCommands
{
    public class UpdateDropOffLocationCommand : IRequest
    {
        public int DropOffLocationId { get; set; }
        public string? Name { get; set; }
    }
}

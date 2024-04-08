using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands; 
using CarBookProject.Application.Features.Mediator.Queries.ReviewQueries;
using CarBookProject.Application.Validators.ReviewValidators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetReviews() 
		{
			var reviews = await _mediator.Send(new GetReviewQuery()); 
			return Ok(reviews);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetReview(int id) 
		{
			var review = await _mediator.Send(new GetReviewByIdQuery(id)); 
			return Ok(review);
		}

		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand command) 
		{
			CreateReviewValidator validator = new CreateReviewValidator();
			var validationResult = validator.Validate(command);

		    if (!validationResult.IsValid) 
			{
				return BadRequest(validationResult.Errors);
			}
			await _mediator.Send(command);
			return Ok("Review added successfully");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteReview(int id) 
		{
			await _mediator.Send(new RemoveReviewCommand(id)); 
			return Ok("Review removed successfully");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateReview(UpdateReviewCommand command) 
		{
			await _mediator.Send(command);
			return Ok("Review updated successfully");
		}

		[HttpGet("GetReviewsByCarId")]
		public async Task<IActionResult> GetReviewsByCarId(int id)
		{
			var reviews = await _mediator.Send(new GetReviewByCarIdQuery(id)); 
			return Ok(reviews);
		}
	}
}

using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;

namespace CarBookProject.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.Rating)
                .NotEmpty().WithMessage("Rating is required.")
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

            RuleFor(x => x.Comment)
                .MaximumLength(500).WithMessage("Comment cannot exceed 500 characters.");

            RuleFor(x => x.DatePosted)
                .NotEmpty().WithMessage("Date posted is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Date posted cannot be in the future.");

            RuleFor(x => x.CarId)
                .NotEmpty().WithMessage("Car ID is required.")
                .GreaterThan(0).WithMessage("Car ID must be greater than 0.");

            RuleFor(x => x.AppUserId)
                .NotEmpty().WithMessage("User ID is required.")
                .GreaterThan(0).WithMessage("User ID must be greater than 0.");
        }
    }
}

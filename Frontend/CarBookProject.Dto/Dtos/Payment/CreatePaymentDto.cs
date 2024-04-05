using System.ComponentModel.DataAnnotations;

namespace CarBookProject.Dto.Dtos.Payment
{
    public class CreatePaymentDto
    {
        [Required(ErrorMessage = "Credit card number is required.")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Please enter a valid credit card number.")]
        public string? CardNumber { get; set; }

        [Required(ErrorMessage = "Cardholder name is required.")]
        public string? CardHolderName { get; set; }

        [Required(ErrorMessage = "Expiry date is required.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Please enter a valid expiry date. (MM/YY)")]
        public string? ExpiryDate { get; set; }

        [Required(ErrorMessage = "CVV code is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Please enter a valid CVV code.")]
        public string? CVV { get; set; }
        public int AppUserId { get; set; }
        public int ReservationId { get; set; }
    }
}

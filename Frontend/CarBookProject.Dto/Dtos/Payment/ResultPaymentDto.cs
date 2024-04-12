namespace CarBookProject.Dto.Dtos.Payment
{
    public class ResultPaymentDto
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int AppUserId { get; set; }
        public string? AppUserName { get; set; }
        public int ReservationId { get; set; }
        public string? Status { get; set; }
        public string? Method { get; set; }
        public decimal TransactionFee { get; set; }
    }
}

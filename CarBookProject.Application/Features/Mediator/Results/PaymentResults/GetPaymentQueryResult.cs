﻿using CarBook.Domain.Enums;

namespace CarBookProject.Application.Features.Mediator.Results.PaymentResults
{
    public class GetPaymentQueryResult
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

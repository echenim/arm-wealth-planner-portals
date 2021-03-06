﻿using System;

namespace Portal.Domain.Models
{
    public class DDebit
    {
        public int Id { get; set; }
        public string DirectDebitReference { get; set; }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public decimal DebitAmount { get; set; }
        public string CustomerId { get; set; }
        public string CardType { get; set; }
        public string CardMask { get; set; }
        public decimal AmountApproved { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

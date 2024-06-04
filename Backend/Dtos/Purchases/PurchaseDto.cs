using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Purchases
{
    public class PurchaseDto
    {
        public int PurchaseId { get; set; }
        public int CourseId { get; set; }
        public string UserId { get; set; }
        public int CreditCardId { get; set; }
        public DateTime PurchasedOn { get; set; }
        public decimal Spend { get; set; }
    }
}
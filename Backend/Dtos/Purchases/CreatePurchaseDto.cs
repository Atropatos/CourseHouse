using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Purchases
{
    public class CreatePurchaseDto
    {
        public int CourseId { get; set; }
        public int CreditCardId { get; set; }
    }
}
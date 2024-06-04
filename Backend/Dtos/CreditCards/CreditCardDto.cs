using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.CreditCards
{
    public class CreditCardDto
    {
        public int CreditCardId { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
        public string HolderName { get; set; }
        public string UserId { get; set; }
    }
}
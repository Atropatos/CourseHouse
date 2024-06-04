using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.CreditCards
{
    public class CreateCreditCardDto
    {
        public string CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
        public string HolderName { get; set; }
    }
}
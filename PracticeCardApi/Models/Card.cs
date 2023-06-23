using System.ComponentModel.DataAnnotations;

namespace PracticeCardApi.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }
        public string CardholderName { get; set; }
        public string CardholderNumber{get; set; }
        public int ExpiryMonth {get ; set;}
        public int ExpiryYear { get; set; }  
        public int CVV { get ; set;}
        

    }
}

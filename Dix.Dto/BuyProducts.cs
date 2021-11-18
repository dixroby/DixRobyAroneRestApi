using System;

namespace Dix.Dto
{
    public class BuyProducts
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

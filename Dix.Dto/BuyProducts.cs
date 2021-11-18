using System;
using System.Collections.Generic;

namespace Dix.Dto
{
    public class BuyProducts
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public List<BuyProductDetails> BuyProductDetails { get; set; }
    }
}

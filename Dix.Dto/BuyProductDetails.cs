namespace Dix.Dto
{
    public class BuyProductDetails
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BuyProductId { get; set; }
        public int ProductId { get; set; }
        public BuyProducts BuyProduct { get; set; }
        public Products Product { get; set; }
    }
}

namespace Chocolate.DataAccess.Models
{
    public class OfferItem : Entity
    {
        public int Quantity { get; set; }
        public Offer Offer { get; set; }
        public int OfferId { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public int RawMaterialId { get; set; }
    }
}

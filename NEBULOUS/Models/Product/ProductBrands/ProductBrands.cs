namespace NEBULOUS.Models.Product.ProductBrands
{
    public class ProductBrands
    {
        public int? id { get; set; }
        public required int idSupplier { get; set; }
        public required string brand { get; set; }
    }
}

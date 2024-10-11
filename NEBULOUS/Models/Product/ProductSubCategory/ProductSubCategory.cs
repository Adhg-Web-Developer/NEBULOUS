namespace NEBULOUS.Models.Product.ProductSubCategory
{
    public class ProductSubCategory
    {
        public int? id { get; set; }
        public required int idProductCategory { get; set; }
        public required string product { get; set; }
        public required string details { get; set; }
    }
}

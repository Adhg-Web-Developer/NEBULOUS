namespace NEBULOUS.Models.Product.Product
{
    public class Product
    {
        public int? id { get; set; }
        public required int idProductSubCategory { get; set; }
        public required int idBrand { get; set; }
        public required int idCategory { get; set; }
        public required string unity { get; set; }
        public required string extent { get; set; }
    }
}

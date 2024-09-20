namespace NEBULOUS.Models.Operation
{
    public class Operation
    {
        public required int idMovementType { get; set; }
        public required int idSupplier { get; set; }
        public required string concept { get; set; }
        public required string codeReference { get; set; }
    }
}

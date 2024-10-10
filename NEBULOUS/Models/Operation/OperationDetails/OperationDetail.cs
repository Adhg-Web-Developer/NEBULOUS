namespace NEBULOUS.Models.Operation.OperationDetails
{
    public class OperationDetail
    {
        public required int idMovementType { get; set; }
        public required string codeReferenceOperation { get; set; }
        public required int idProduct { get; set; }
        public required float unityCost { get; set; }
        public required float unityPrice { get; set; }
        public required float amout { get; set; }
        public required float subtotal { get; set; }
    }
}

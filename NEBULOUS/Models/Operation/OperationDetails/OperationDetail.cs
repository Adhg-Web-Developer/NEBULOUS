﻿namespace NEBULOUS.Models.Operation.OperationDetails
{
    public class OperationDetail
    {
        public int? id { get; set; }
        public required int idMovementType { get; set; }
        public required string codeReferenceOperation { get; set; }
        public required int idProduct { get; set; }
        public required float unityCost { get; set; }
        public required float unityPrice { get; set; }
        public required float amount { get; set; }
    }
}

﻿namespace NEBULOUS.Models.Operation.Operation
{
    public class Operation
    {
        public int? id {  get; set; }
        public required int idMovementType { get; set; }
        public required int idSupplier { get; set; }
        public required string concept { get; set; }
        public required string codeReference { get; set; }
    }
}

using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Commands.Dtos
{
    [DataContract]
    public class FiscalReceiptItem
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string VatRateLetter { get; set; }

        [DataMember]
        public decimal GrossValue { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public decimal UnitGrossValue { get; set; }
    }
}

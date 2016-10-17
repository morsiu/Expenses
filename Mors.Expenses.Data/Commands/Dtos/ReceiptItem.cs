using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Commands.Dtos
{
    [DataContract]
    public class ReceiptItem
    {
        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string VatRateLetter { get; private set; }

        [DataMember]
        public decimal GrossValue { get; private set; }

        [DataMember]
        public decimal Amount { get; private set; }

        [DataMember]
        public decimal UnitGrossValue { get; private set; }
    }
}

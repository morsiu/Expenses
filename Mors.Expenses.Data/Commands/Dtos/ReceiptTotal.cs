using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Commands.Dtos
{
    [DataContract]
    public class ReceiptTotal
    {
        [DataMember]
        public string VatRateLetter { get; private set; }

        [DataMember]
        public decimal VatRatePercentValue { get; private set; }

        [DataMember]
        public decimal VatValue { get; private set; }

        [DataMember]
        public decimal GrossValue { get; private set; }
    }
}

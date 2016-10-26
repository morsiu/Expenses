using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Commands.Dtos
{
    [DataContract]
    public class FiscalReceiptTotal
    {
        [DataMember]
        public string VatRateLetter { get; set; }

        [DataMember]
        public decimal VatRatePercentValue { get; set; }

        [DataMember]
        public decimal VatValue { get; set; }

        [DataMember]
        public decimal GrossValue { get; set; }
    }
}

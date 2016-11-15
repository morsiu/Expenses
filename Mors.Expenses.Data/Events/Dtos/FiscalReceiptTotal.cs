using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Events.Dtos
{
    [DataContract]
    public sealed class FiscalReceiptTotal
    {
        public FiscalReceiptTotal(
            string vatRateLetter,
            decimal vatRatePercentValue,
            decimal vatValue,
            decimal grossValue)
        {
            VatRateLetter = vatRateLetter;
            VatRatePercentValue = vatRatePercentValue;
            VatValue = vatValue;
            GrossValue = grossValue;
        }

        [DataMember]
        public decimal GrossValue { get; }

        [DataMember]
        public string VatRateLetter { get; }

        [DataMember]
        public decimal VatRatePercentValue { get; }

        [DataMember]
        public decimal VatValue { get; }
    }
}

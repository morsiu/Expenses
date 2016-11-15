using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Events.Dtos
{
    [DataContract]
    public sealed class FiscalReceiptDiscountOrMarkup
    {
        public FiscalReceiptDiscountOrMarkup(
            string name,
            string vatRateLetter,
            decimal value)
        {
            Name = name;
            VatRateLetter = vatRateLetter;
            Value = value;
        }

        [DataMember]
        public string Name { get; }

        [DataMember]
        public decimal Value { get; }

        [DataMember]
        public string VatRateLetter { get; }
    }
}

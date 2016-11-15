using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Events.Dtos
{
    [DataContract]
    public sealed class FiscalReceiptItem
    {
        public FiscalReceiptItem(
            string name,
            string vatRateLetter,
            decimal amount,
            decimal unitGrossValue,
            decimal grossValue)
        {
            Name = name;
            VatRateLetter = vatRateLetter;
            Amount = amount;
            UnitGrossValue = unitGrossValue;
            GrossValue = grossValue;
        }

        [DataMember]
        public decimal Amount { get; }

        [DataMember]
        public decimal GrossValue { get; }

        [DataMember]
        public string Name { get; }

        [DataMember]
        public decimal UnitGrossValue { get; }

        [DataMember]
        public string VatRateLetter { get; }
    }
}

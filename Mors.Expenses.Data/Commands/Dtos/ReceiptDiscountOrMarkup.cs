using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Commands.Dtos
{
    [DataContract]
    public class ReceiptDiscountOrMarkup
    {
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the value of the markup/discount. In case of a discount, the value is negative; in case of a markup it is positive.
        /// </summary>
        [DataMember]
        public decimal Value { get; private set; }
        
        [DataMember]
        public string VatRateLetter { get; private set; }
    }
}

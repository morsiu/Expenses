using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Commands.Dtos
{
    [DataContract]
    public class FiscalReceiptDiscountOrMarkup
    {
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the markup/discount. In case of a discount, the value is negative; in case of a markup it is positive.
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }
        
        [DataMember]
        public string VatRateLetter { get; set; }
    }
}

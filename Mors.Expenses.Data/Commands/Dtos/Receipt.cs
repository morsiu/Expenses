using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Commands.Dtos
{
    /// <summary>
    /// Represents a receipt in the form of "paragon fiskalny".
    /// </summary>
    [DataContract]
    public class Receipt
    {
        /// <summary>
        /// Gets the unique id of the receipt
        /// </summary>
        [DataMember]
        public object ReceiptId { get; private set; }

        /// <summary>
        /// Gets the state registered name of the tax payer.
        /// </summary>
        [DataMember]
        public string TaxPayerName { get; private set; }

        /// <summary>
        /// Gets the state registered address of the tax payer.
        /// </summary>
        [DataMember]
        public string TaxPayerAddress { get; private set; }

        /// <summary>
        /// Gets the tax payer's VAT identification number.
        /// </summary>
        [DataMember]
        public string TaxPayerNip { get; private set; }

        /// <summary>
        /// Gets the date and time of the sale.
        /// </summary>
        [DataMember]
        public DateTime TimeAndDateOfSale { get; private set; }

        /// <summary>
        /// Gets the list of items.
        /// </summary>
        [DataMember]
        public IReadOnlyList<ReceiptItem> Items { get; private set; }

        /// <summary>
        /// Gets the list of discounts and markups.
        /// </summary>
        [DataMember]
        public IReadOnlyList<ReceiptDiscountOrMarkup> DiscountsAndMarkups { get; private set; }

        /// <summary>
        /// Gets the gross totals of items, for each VAT rate, after including the discounts and markups.
        /// </summary>
        [DataMember]
        public IReadOnlyList<ReceiptTotal> TotalsPerVatRate { get; private set; }

        /// <summary>
        /// Get the gross total.
        /// </summary>
        [DataMember]
        public decimal GrossTotal { get; private set; }

        /// <summary>
        /// Gets the VAT total.
        /// </summary>
        [DataMember]
        public decimal VatTotal { get; private set; }

        /// <summary>
        /// Gets the currency code (PLN, EUR etc.)
        /// </summary>
        [DataMember]
        public string CurrencyCode { get; private set; }

        /// <summary>
        /// Gets the the payment form.
        /// </summary>
        [DataMember]
        public string PaymentForm { get; private set; }

        /// <summary>
        /// Gets the total paid by the buyer.
        /// </summary>
        [DataMember]
        public decimal PaymentTotal { get; private set; }

        /// <summary>
        /// Gets the amount of change returned back to the buyer, when the payment was done in cash; null when the payment was not done in cash.
        /// </summary>
        [DataMember]
        public decimal? CashPaymentChange { get; private set; }
    }
}

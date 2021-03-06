﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Commands.Dtos
{
    /// <summary>
    /// Represents a fiscal receipt.
    /// </summary>
    [DataContract]
    public class FiscalReceipt
    {
        /// <summary>
        /// Gets or sets the number of the fiscal receipt.
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the state registered name of the tax payer.
        /// </summary>
        [DataMember]
        public string TaxPayerName { get; set; }

        /// <summary>
        /// Gets or sets the state registered address of the tax payer.
        /// </summary>
        [DataMember]
        public string TaxPayerAddress { get; set; }

        /// <summary>
        /// Gets or sets the tax payer's VAT identification number.
        /// </summary>
        [DataMember]
        public string TaxPayerNip { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the sale.
        /// </summary>
        [DataMember]
        public DateTime TimeAndDateOfSale { get; set; }

        /// <summary>
        /// Gets or sets the address of the sale place.
        /// </summary>
        [DataMember]
        public string AddressOfSalePlace { get; set; }

        /// <summary>
        /// Gets or sets the name of the sale place
        /// </summary>
        [DataMember]
        public string NameOfSalePlace { get; set; }

        /// <summary>
        /// Gets or sets the list of items.
        /// </summary>
        [DataMember]
        public IReadOnlyList<FiscalReceiptItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the list of discounts and markups.
        /// </summary>
        [DataMember]
        public IReadOnlyList<FiscalReceiptDiscountOrMarkup> DiscountsAndMarkups { get; set; }

        /// <summary>
        /// Gets or sets the gross totals of items, for each VAT rate, after including the discounts and markups.
        /// </summary>
        [DataMember]
        public IReadOnlyList<FiscalReceiptTotal> TotalsPerVatRate { get; set; }

        /// <summary>
        /// Get the gross total.
        /// </summary>
        [DataMember]
        public decimal GrossTotal { get; set; }

        /// <summary>
        /// Gets or sets the VAT total.
        /// </summary>
        [DataMember]
        public decimal VatTotal { get; set; }

        /// <summary>
        /// Gets or sets the currency code (PLN, EUR etc.)
        /// </summary>
        [DataMember]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the the payment form.
        /// </summary>
        [DataMember]
        public string PaymentForm { get; set; }

        /// <summary>
        /// Gets or sets the total paid by the buyer.
        /// </summary>
        [DataMember]
        public decimal PaymentTotal { get; set; }

        /// <summary>
        /// Gets or sets the amount of change returned back to the buyer, when the payment was done in cash; null when the payment was not done in cash.
        /// </summary>
        [DataMember]
        public decimal? CashPaymentChange { get; set; }
    }
}

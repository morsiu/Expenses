using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Events.Dtos
{
    public sealed class FiscalReceipt
    {
        public FiscalReceipt(
            string taxPayerName,
            string taxPayerAddress,
            string taxPayerNip,
            string salePlaceAddress,
            string salePlaceName,
            DateTime timeAndDateOfSale,
            IReadOnlyList<FiscalReceiptItem> items,
            IReadOnlyList<FiscalReceiptDiscountOrMarkup> discountsAndMarkups,
            IReadOnlyDictionary<string, FiscalReceiptTotal> totalsByVatRateLetter,
            decimal grossTotal,
            decimal vatTotal,
            decimal paymentTotal,
            string paymentForm,
            decimal? cashPaymentChange,
            string currencyCode)
        {
            TaxPayerName = taxPayerName;
            TaxPayerAddress = taxPayerAddress;
            TaxPayerNip = taxPayerNip;
            SalePlaceAddress = salePlaceAddress;
            SalePlaceName = salePlaceName;
            TimeAndDateOfSale = timeAndDateOfSale;
            Items = items;
            DiscountsAndMarkups = discountsAndMarkups;
            TotalsByVatRateLetter = totalsByVatRateLetter;
            GrossTotal = grossTotal;
            VatTotal = vatTotal;
            PaymentTotal = paymentTotal;
            PaymentForm = paymentForm;
            CashPaymentChange = cashPaymentChange;
            CurrencyCode = currencyCode;
        }

        [DataMember]
        public decimal? CashPaymentChange { get; }

        [DataMember]
        public string CurrencyCode { get; }

        [DataMember]
        public IReadOnlyList<FiscalReceiptDiscountOrMarkup> DiscountsAndMarkups { get; }

        [DataMember]
        public decimal GrossTotal { get; }

        [DataMember]
        public IReadOnlyList<FiscalReceiptItem> Items { get; }

        [DataMember]
        public string PaymentForm { get; }

        [DataMember]
        public decimal PaymentTotal { get; }

        [DataMember]
        public string SalePlaceAddress { get; }

        [DataMember]
        public string SalePlaceName { get; }

        [DataMember]
        public string TaxPayerAddress { get; }

        [DataMember]
        public string TaxPayerName { get; }

        [DataMember]
        public string TaxPayerNip { get; }

        [DataMember]
        public DateTime TimeAndDateOfSale { get; }

        [DataMember]
        public IReadOnlyDictionary<string, FiscalReceiptTotal> TotalsByVatRateLetter { get; }

        [DataMember]
        public decimal VatTotal { get; }
    }
}

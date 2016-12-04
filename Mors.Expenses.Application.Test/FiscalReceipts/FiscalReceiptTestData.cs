using System;
using Mors.Expenses.Data.Commands.Dtos;

namespace Mors.Expenses.Application.Test.FiscalReceipts
{
    public static class FiscalReceiptTestData
    {
        public static FiscalReceiptItem ValidReceiptItem()
        {
            return new FiscalReceiptItem
            {
                Amount = 0.574m,
                GrossValue = 9.18m,
                Name = "D_FILET Z KURCZ.*2",
                UnitGrossValue = 15.99m,
                VatRateLetter = "D"
            };
        }

        public static FiscalReceiptTotal ValidTotal()
        {
            return new FiscalReceiptTotal
            {
                GrossValue = 20.48m,
                VatRateLetter = "D",
                VatRatePercentValue = 23m,
                VatValue = 3.83m
            };
        }
        public static FiscalReceiptDiscountOrMarkup ValidDiscountOrMarkup()
        {
            return new FiscalReceiptDiscountOrMarkup
            {
                Name = "Rabat JOG ZOT 370G +1ZA50%",
                Value = -1.88m,
                VatRateLetter = "D"
            };
        }

        public static FiscalReceipt ValidReceipt()
        {
            return new FiscalReceipt()
            {
                TaxPayerName = "CARREFOUR Polska Sp. z o. o.",
                TaxPayerAddress = "03-734 Warszawa ul. Targowa 72",
                TaxPayerNip = "937-00-08-168",
                AddressOfSalePlace = "00-175 Warszawa ul. Jana Pawła II 82",
                NameOfSalePlace = "* CARREFOUR * CH Arkadia",
                CurrencyCode = "PLN",
                PaymentForm = "KARTAPŁATNI",
                TimeAndDateOfSale = new DateTime(2005, 1, 1),
                Items = new FiscalReceiptItem[]
                {
                    new FiscalReceiptItem
                    {
                        Amount = 1m,
                        GrossValue = 1.76m,
                        Name = "D_SEREK WIEJSKI PIA",
                        UnitGrossValue = 1.76m,
                        VatRateLetter = "D"
                    }
                },
                TotalsPerVatRate = new FiscalReceiptTotal[]
                {
                    new FiscalReceiptTotal
                    {
                        GrossValue = 1.76m,
                        VatRateLetter = "D",
                        VatRatePercentValue = 5m,
                        VatValue = 0.08m
                    }
                }
            };
        }
    }
}
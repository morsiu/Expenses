using System;
using System.Collections.Generic;
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
            return new FiscalReceipt
            {
                TaxPayerName = "CARREFOUR Polska Sp. z o. o.",
                TaxPayerAddress = "03-734 Warszawa ul. Targowa 72",
                TaxPayerNip = "937-00-08-168",
                AddressOfSalePlace = "00-175 Warszawa ul. Jana Pawła II 82",
                NameOfSalePlace = "* CARREFOUR * CH Arkadia",
                CurrencyCode = "PLN",
                PaymentForm = "KARTAPŁATNI",
                TimeAndDateOfSale = new DateTime(2005, 1, 1),
                Items = new[] { ValidReceiptItem() },
                TotalsPerVatRate = new[] { ValidTotal() }
            };
        }
        
        public static IEnumerable<FiscalReceiptItem> InvalidReceiptItems()
        {
            yield return default(FiscalReceiptItem);
            var validItem = new Modify<FiscalReceiptItem>(ValidReceiptItem);
            yield return validItem.Modified(ri => { ri.Name = null; });
            yield return validItem.Modified(ri => { ri.Name = ""; });
            yield return validItem.Modified(ri => { ri.Name = " "; });
            yield return validItem.Modified(ri => { ri.VatRateLetter = null; });
            yield return validItem.Modified(ri => { ri.VatRateLetter = ""; });
            yield return validItem.Modified(ri => { ri.VatRateLetter = " "; });
        }        
        
        public static IEnumerable<FiscalReceiptDiscountOrMarkup> InvalidDiscountOrMarkups()
        {
            yield return default(FiscalReceiptDiscountOrMarkup);
            var validDiscountOrMarkup = new Modify<FiscalReceiptDiscountOrMarkup>(ValidDiscountOrMarkup);
            yield return validDiscountOrMarkup.Modified(dm => { dm.Name = null; });
            yield return validDiscountOrMarkup.Modified(dm => { dm.Name = ""; });
            yield return validDiscountOrMarkup.Modified(dm => { dm.Name = " "; });
            yield return validDiscountOrMarkup.Modified(dm => { dm.VatRateLetter = null; });
            yield return validDiscountOrMarkup.Modified(dm => { dm.VatRateLetter = ""; });
            yield return validDiscountOrMarkup.Modified(dm => { dm.VatRateLetter = " "; });
        }        

        public static IEnumerable<FiscalReceipt> InvalidReceipts()
        {
            yield return default(FiscalReceipt);
            var validReceipt = new Modify<FiscalReceipt>(ValidReceipt);
            yield return default(FiscalReceipt);
            yield return validReceipt.Modified(r => { r.TaxPayerName = null; });
            yield return validReceipt.Modified(r => { r.TaxPayerName = string.Empty; });
            yield return validReceipt.Modified(r => { r.TaxPayerName = " "; });
            yield return validReceipt.Modified(r => { r.TaxPayerAddress = null; });
            yield return validReceipt.Modified(r => { r.TaxPayerAddress = string.Empty; });
            yield return validReceipt.Modified(r => { r.TaxPayerAddress = " "; });
            yield return validReceipt.Modified(r => { r.TaxPayerNip = null; });
            yield return validReceipt.Modified(r => { r.TaxPayerNip = string.Empty; });
            yield return validReceipt.Modified(r => { r.TaxPayerNip = " "; });
            yield return validReceipt.Modified(r => { r.AddressOfSalePlace = null; });
            yield return validReceipt.Modified(r => { r.AddressOfSalePlace = string.Empty; });
            yield return validReceipt.Modified(r => { r.AddressOfSalePlace = " "; });
            yield return validReceipt.Modified(r => { r.NameOfSalePlace = null; });
            yield return validReceipt.Modified(r => { r.NameOfSalePlace = string.Empty; });
            yield return validReceipt.Modified(r => { r.NameOfSalePlace = " "; });
            yield return validReceipt.Modified(r => { r.CurrencyCode = null; });
            yield return validReceipt.Modified(r => { r.CurrencyCode = string.Empty; });
            yield return validReceipt.Modified(r => { r.CurrencyCode = " "; });
            yield return validReceipt.Modified(r => { r.PaymentForm = null; });
            yield return validReceipt.Modified(r => { r.PaymentForm = string.Empty; });
            yield return validReceipt.Modified(r => { r.PaymentForm = " "; });
            yield return validReceipt.Modified(r => { r.TimeAndDateOfSale = new DateTime(2004, 12, 31, 23, 59, 59); });
            yield return validReceipt.Modified(r => { r.TaxPayerNip = "0000000000"; });
            yield return validReceipt.Modified(r => { r.Items = null; });
            yield return validReceipt.Modified(r => { r.Items = new FiscalReceiptItem[0]; });
            yield return validReceipt.Modified(r => { r.Items = new FiscalReceiptItem[] { null }; });
            yield return validReceipt.Modified(r => { r.DiscountsAndMarkups = new FiscalReceiptDiscountOrMarkup[] { null }; });
            yield return validReceipt.Modified(r => { r.TotalsPerVatRate = null; });
            yield return validReceipt.Modified(r => { r.TotalsPerVatRate = new FiscalReceiptTotal[0]; });
            yield return validReceipt.Modified(r => { r.TotalsPerVatRate = new FiscalReceiptTotal[] { null }; });
            yield return validReceipt.Modified(r => { r.Items = new[] { new FiscalReceiptItem { Name = "1", VatRateLetter = "A" },
                                                                        new FiscalReceiptItem { Name = "2", VatRateLetter = "B" } };
                                                      r.TotalsPerVatRate = new[] { new FiscalReceiptTotal { VatRateLetter = "A" } }; });
            yield return validReceipt.Modified(r => { r.Items = new[] { new FiscalReceiptItem { Name = "1", VatRateLetter = "A" } };
                                                      r.TotalsPerVatRate = new[] { new FiscalReceiptTotal { VatRateLetter = "A" },
                                                                                   new FiscalReceiptTotal { VatRateLetter = "B" } }; });
            yield return validReceipt.Modified(r => { r.DiscountsAndMarkups = new[] { new FiscalReceiptDiscountOrMarkup { Name = "1", VatRateLetter = "B" } };
                                                      r.Items = new[] { new FiscalReceiptItem { Name = "1", VatRateLetter = "A" } };
                                                      r.TotalsPerVatRate = new[] { new FiscalReceiptTotal { VatRateLetter = "A" } }; });
            yield return validReceipt.Modified(r => { r.Items = new[] { new FiscalReceiptItem { Name = "1", VatRateLetter = "A" } };
                                                      r.TotalsPerVatRate = new[] { new FiscalReceiptTotal { VatRateLetter = "A" },
                                                                                   new FiscalReceiptTotal { VatRateLetter = "A" } }; });
        }
        
        public static IEnumerable<FiscalReceiptTotal> InvalidTotals()
        {
            yield return default(FiscalReceiptTotal);
            var validTotal = new Modify<FiscalReceiptTotal>(ValidTotal);
            yield return validTotal.Modified(t => { t.VatRateLetter = null; });
            yield return validTotal.Modified(t => { t.VatRateLetter = ""; });
            yield return validTotal.Modified(t => { t.VatRateLetter = " "; });
            yield return validTotal.Modified(t => { t.VatRatePercentValue = -4m; });
        }        

        private sealed class Modify<T>
        {
            private readonly Func<T> _initial;

            public Modify(Func<T> initial)
            {
                _initial = initial;
            }

            public T Modified(Action<T> modify)
            {
                var initial = _initial();
                modify(initial);
                return initial;
            }
        }
    }
}
using Mors.Expenses.Application.FiscalReceipts;
using Mors.Expenses.Data.Commands.Dtos;
using System.Collections.Generic;
using Xunit;
using System;
using System.Linq;
using System.Collections;

namespace Mors.Expenses.Application.Test.FiscalReceipts
{
    public static class FiscalReceiptValidatorUnitTest
    {
        [Fact]
        public static void Validate_Returns_True_Given_Valid_Receipt()
        {
            var isValid = FiscalReceiptValidator.Validate(ValidReceipt());
            Assert.True(isValid);
        }

        [Theory]
        [MemberData("InvalidReceipts")]
        public static void Validate_Returns_False_Given_Invalid_Receipt(FiscalReceipt invalidReceipt)
        {
            var isValid = FiscalReceiptValidator.Validate(invalidReceipt);
            Assert.False(isValid);
        }

        public static IEnumerable InvalidReceipts()
        {
            yield return Row(default(FiscalReceipt));
            yield return Row(ModifyValidReceipt(r => { r.TaxPayerName = null; }));
            yield return Row(ModifyValidReceipt(r => { r.TaxPayerName = string.Empty; }));
            yield return Row(ModifyValidReceipt(r => { r.TaxPayerName = " "; }));
            yield return Row(ModifyValidReceipt(r => { r.TaxPayerAddress = null; }));
            yield return Row(ModifyValidReceipt(r => { r.TaxPayerAddress = string.Empty; }));
            yield return Row(ModifyValidReceipt(r => { r.TaxPayerAddress = " "; }));
            yield return Row(ModifyValidReceipt(r => { r.TaxPayerNip = null; }));
            yield return Row(ModifyValidReceipt(r => { r.TaxPayerNip = string.Empty; }));
            yield return Row(ModifyValidReceipt(r => { r.TaxPayerNip = " "; }));
            yield return Row(ModifyValidReceipt(r => { r.AddressOfSalePlace = null; }));
            yield return Row(ModifyValidReceipt(r => { r.AddressOfSalePlace = string.Empty; }));
            yield return Row(ModifyValidReceipt(r => { r.AddressOfSalePlace = " "; }));
            yield return Row(ModifyValidReceipt(r => { r.NameOfSalePlace = null; }));
            yield return Row(ModifyValidReceipt(r => { r.NameOfSalePlace = string.Empty; }));
            yield return Row(ModifyValidReceipt(r => { r.NameOfSalePlace = " "; }));
            yield return Row(ModifyValidReceipt(r => { r.CurrencyCode = null; }));
            yield return Row(ModifyValidReceipt(r => { r.CurrencyCode = string.Empty; }));
            yield return Row(ModifyValidReceipt(r => { r.CurrencyCode = " "; }));
            yield return Row(ModifyValidReceipt(r => { r.PaymentForm = null; }));
            yield return Row(ModifyValidReceipt(r => { r.PaymentForm = string.Empty; }));
            yield return Row(ModifyValidReceipt(r => { r.PaymentForm = " "; }));
            yield return Row(ModifyValidReceipt(r => { r.TimeAndDateOfSale = new DateTime(2004, 12, 31, 23, 59, 59); }));
            yield return Row(ModifyValidReceipt(r => { r.TaxPayerNip = "0000000000"; }));
            yield return Row(ModifyValidReceipt(r => { r.Items = null; }));
            yield return Row(ModifyValidReceipt(r => { r.Items = new FiscalReceiptItem[0]; }));
            yield return Row(ModifyValidReceipt(r => { r.Items = new FiscalReceiptItem[] { null }; }));
            yield return Row(ModifyValidReceipt(r => { r.DiscountsAndMarkups = new FiscalReceiptDiscountOrMarkup[] { null }; }));
            yield return Row(ModifyValidReceipt(r => { r.TotalsPerVatRate = null; }));
            yield return Row(ModifyValidReceipt(r => { r.TotalsPerVatRate = new FiscalReceiptTotal[0]; }));
            yield return Row(ModifyValidReceipt(r => { r.TotalsPerVatRate = new FiscalReceiptTotal[] { null }; }));
        }

        private static FiscalReceipt ModifyValidReceipt(Action<FiscalReceipt> change)
        {
            FiscalReceipt receipt = ValidReceipt();
            change(receipt);
            return receipt;
        }

        private static IEnumerable Row(params object[] parameters)
        {
            return parameters;
        }

        private static FiscalReceipt ValidReceipt()
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

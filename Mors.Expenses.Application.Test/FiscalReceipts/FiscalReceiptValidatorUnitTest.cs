using Mors.Expenses.Application.FiscalReceipts;
using Mors.Expenses.Data.Commands.Dtos;
using System.Collections.Generic;
using Xunit;
using System;
using System.Linq;

namespace Mors.Expenses.Application.Test.FiscalReceipts
{
    public static class FiscalReceiptValidatorUnitTest
    {
        [Fact]
        public static void Validate_Returns_Result_With_Empty_ReceiptValidationErrors_Given_Valid_Receipt()
        {
            var validationResult = FiscalReceiptValidator.Validate(ValidReceipt());
            Assert.NotNull(validationResult);
            AssertEquivalentValidationErrors(Enumerable.Empty<FiscalReceiptValidationError>(), validationResult.ReceiptValidationErrors);
        }

        [Theory]
        [MemberData("FiscalReceiptValidationErrorsToInvalidReceipts")]
        public static void Validate_Returns_Result_With_Expected_ReceiptValidationErrors_Given_Invalid_Fiscal_Receipt(IEnumerable<FiscalReceiptValidationError> expectedValidationErrors, FiscalReceipt specificFiscalReceipt)
        {
            var validationResult = FiscalReceiptValidator.Validate(specificFiscalReceipt);
            Assert.NotNull(validationResult);
            AssertEquivalentValidationErrors(expectedValidationErrors, validationResult.ReceiptValidationErrors);
        }

        [Fact]
        public static void Validate_Can_Return_Result_With_ReceiptValidationErrors_With_Two_Validation_Errors()
        {
            var receipt = ChangedValidReceipt(r => { r.TaxPayerAddress = null; r.TaxPayerName = null; });
            var result = FiscalReceiptValidator.Validate(receipt);
            AssertEquivalentValidationErrors(new[] { FiscalReceiptValidationError.MissingTaxPayerAddress, FiscalReceiptValidationError.MissingTaxPayerName }, result.ReceiptValidationErrors);
        }

        public static IEnumerable<object[]> FiscalReceiptValidationErrorsToInvalidReceipts()
        {
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingFiscalReceipt, null);
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingTaxPayerName, ChangedValidReceipt(r => { r.TaxPayerName = null; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingTaxPayerName, ChangedValidReceipt(r => { r.TaxPayerName = string.Empty; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingTaxPayerName, ChangedValidReceipt(r => { r.TaxPayerName = " "; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingTaxPayerAddress, ChangedValidReceipt(r => { r.TaxPayerAddress = null; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingTaxPayerAddress, ChangedValidReceipt(r => { r.TaxPayerAddress = string.Empty; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingTaxPayerAddress, ChangedValidReceipt(r => { r.TaxPayerAddress = " "; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingTaxPayerNip, ChangedValidReceipt(r => { r.TaxPayerNip = null; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingTaxPayerNip, ChangedValidReceipt(r => { r.TaxPayerNip = string.Empty; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingTaxPayerNip, ChangedValidReceipt(r => { r.TaxPayerNip = " "; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingAddressOfSalePlace, ChangedValidReceipt(r => { r.AddressOfSalePlace = null; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingAddressOfSalePlace, ChangedValidReceipt(r => { r.AddressOfSalePlace = string.Empty; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingAddressOfSalePlace, ChangedValidReceipt(r => { r.AddressOfSalePlace = " "; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingNameOfSalePlace, ChangedValidReceipt(r => { r.NameOfSalePlace = null; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingNameOfSalePlace, ChangedValidReceipt(r => { r.NameOfSalePlace = string.Empty; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingNameOfSalePlace, ChangedValidReceipt(r => { r.NameOfSalePlace = " "; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingCurrencyCode, ChangedValidReceipt(r => { r.CurrencyCode = null; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingCurrencyCode, ChangedValidReceipt(r => { r.CurrencyCode = string.Empty; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingCurrencyCode, ChangedValidReceipt(r => { r.CurrencyCode = " "; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingPaymentForm, ChangedValidReceipt(r => { r.PaymentForm = null; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingPaymentForm, ChangedValidReceipt(r => { r.PaymentForm = string.Empty; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.MissingPaymentForm, ChangedValidReceipt(r => { r.PaymentForm = " "; }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.TimeAndDateOfSaleBeforeYear2005, ChangedValidReceipt(r => { r.TimeAndDateOfSale = new DateTime(2004, 12, 31, 23, 59, 59); }));
            yield return ValidationErrorToInvalidReceipt(FiscalReceiptValidationError.InvalidTaxPayerNip, ChangedValidReceipt(r => { r.TaxPayerNip = "0000000000"; }));
        }

        private static object[] ValidationErrorToInvalidReceipt(FiscalReceiptValidationError expectedValidationError, FiscalReceipt invalidReceipt)
        {
            return new object[] { new[] { expectedValidationError }, invalidReceipt };
        }

        private static FiscalReceipt ChangedValidReceipt(Action<FiscalReceipt> change)
        {
            FiscalReceipt receipt = ValidReceipt();
            change(receipt);
            return receipt;
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
                TimeAndDateOfSale = new DateTime(2005, 1, 1)
            };
        }

        private static void AssertEquivalentValidationErrors(IEnumerable<FiscalReceiptValidationError> expected, IEnumerable<FiscalReceiptValidationError> actual)
        {
            Assert.Equal(expected.OrderBy(x => x).ToArray(), actual.OrderBy(x => x).ToArray());
        }

    }
}

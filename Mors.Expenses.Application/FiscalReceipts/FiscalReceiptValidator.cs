using System;
using System.Collections.Generic;
using System.Linq;
using Mors.Expenses.Data.Commands.Dtos;

namespace Mors.Expenses.Application.FiscalReceipts
{
    internal static class FiscalReceiptValidator
    {
        public static FiscalReceiptValidationResult Validate(FiscalReceipt fiscalReceipt)
        {
            var validationErrors = ValidateReceipt(fiscalReceipt);
            return new FiscalReceiptValidationResult
            {
                ReceiptValidationErrors = validationErrors.ToList()
            };
        }

        private static IEnumerable<FiscalReceiptValidationError> ValidateReceipt(FiscalReceipt fiscalReceipt)
        {
            if (fiscalReceipt == null)
            {
                yield return FiscalReceiptValidationError.MissingFiscalReceipt;
                yield break;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.TaxPayerName))
            {
                yield return FiscalReceiptValidationError.MissingTaxPayerName;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.TaxPayerAddress))
            {
                yield return FiscalReceiptValidationError.MissingTaxPayerAddress;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.TaxPayerNip))
            {
                yield return FiscalReceiptValidationError.MissingTaxPayerNip;
            }
            else
            {
                if (!NipValidator.Validate(fiscalReceipt.TaxPayerNip))
                {
                    yield return FiscalReceiptValidationError.InvalidTaxPayerNip;
                }
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.AddressOfSalePlace))
            {
                yield return FiscalReceiptValidationError.MissingAddressOfSalePlace;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.NameOfSalePlace))
            {
                yield return FiscalReceiptValidationError.MissingNameOfSalePlace;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.CurrencyCode))
            {
                yield return FiscalReceiptValidationError.MissingCurrencyCode;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.PaymentForm))
            {
                yield return FiscalReceiptValidationError.MissingPaymentForm;
            }
            if (fiscalReceipt.TimeAndDateOfSale < new DateTime(2005, 1, 1))
            {
                yield return FiscalReceiptValidationError.TimeAndDateOfSaleBeforeYear2005;
            }
        }
    }
}

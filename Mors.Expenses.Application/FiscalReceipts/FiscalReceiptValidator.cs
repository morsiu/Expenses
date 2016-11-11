using System;
using Mors.Expenses.Data.Commands.Dtos;

namespace Mors.Expenses.Application.FiscalReceipts
{
    internal static class FiscalReceiptValidator
    {
        public static bool Validate(FiscalReceipt fiscalReceipt)
        {
            if (fiscalReceipt == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.TaxPayerName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.TaxPayerAddress))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.TaxPayerNip))
            {
                return false;
            }
            else
            {
                if (!NipValidator.Validate(fiscalReceipt.TaxPayerNip))
                {
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.AddressOfSalePlace))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.NameOfSalePlace))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.CurrencyCode))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(fiscalReceipt.PaymentForm))
            {
                return false;
            }
            if (fiscalReceipt.TimeAndDateOfSale < new DateTime(2005, 1, 1))
            {
                return false;
            }
            return true;
        }
    }
}

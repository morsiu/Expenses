using Mors.Expenses.Data.Commands.Dtos;

namespace Mors.Expenses.Application.FiscalReceipts
{
    internal static class FiscalReceiptDiscountOrMarkupValidator
    {
        public static bool Validate(FiscalReceiptDiscountOrMarkup discountOrMarkup)
        {
            if (discountOrMarkup == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(discountOrMarkup.VatRateLetter))
            {
                return false;
            }
            return !string.IsNullOrWhiteSpace(discountOrMarkup.Name);
        }
    }
}

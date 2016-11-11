using Mors.Expenses.Data.Commands.Dtos;

namespace Mors.Expenses.Application.FiscalReceipts
{
    internal static class FiscalReceiptTotalValidator
    {
        public static bool Validate(FiscalReceiptTotal total)
        {
            if (total == null)
            {
                return false;
            }
            if (total.VatRatePercentValue < 0m)
            {
                return false;
            }
            return !string.IsNullOrWhiteSpace(total.VatRateLetter);
        }
    }
}

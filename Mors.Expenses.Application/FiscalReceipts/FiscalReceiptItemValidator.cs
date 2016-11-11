﻿using Mors.Expenses.Data.Commands.Dtos;

namespace Mors.Expenses.Application.FiscalReceipts
{
    internal static class FiscalReceiptItemValidator
    {
        public static bool Validate(FiscalReceiptItem item)
        {
            if (item == null)
            {
                return false;
            }
            return !string.IsNullOrWhiteSpace(item.Name);
        }
    }
}

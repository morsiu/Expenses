using System;
using Mors.Expenses.Application.FiscalReceipts;
using Mors.Expenses.Data.Commands.Dtos;
using Xunit;

namespace Mors.Expenses.Application.Test.FiscalReceipts
{
    public class FiscalReceiptItemValidatorUnitTest
    {
        [Fact]
        public void Validate_Returns_True_For_Valid_Receipt_Item()
        {
            Assert.True(FiscalReceiptItemValidator.Validate(ValidReceiptItem()));
        }

        private static FiscalReceiptItem ValidReceiptItem()
        {
            return new FiscalReceiptItem
            {
                Amount = 0.574m,
                GrossValue = 9.18m,
                Name = "D_FILET Z KURCH.*2",
                UnitGrossValue = 15.99m,
                VatRateLetter = "D"
            };
        }
    }
}

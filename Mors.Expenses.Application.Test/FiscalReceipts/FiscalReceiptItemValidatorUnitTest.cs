using System;
using System.Collections;
using System.Collections.Generic;
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
            Assert.True(FiscalReceiptItemValidator.Validate(FiscalReceiptTestData.ValidReceiptItem()));
        }

        [Theory]
        [MemberData("InvalidReceiptItems")]
        public void Validate_Returns_False_For_Invalid_Receipt_Item(FiscalReceiptItem invalidReceiptItem)
        {
            Assert.False(FiscalReceiptItemValidator.Validate(invalidReceiptItem));
        }

        public static IEnumerable<IEnumerable> InvalidReceiptItems()
        {
            yield return Row(default(FiscalReceiptItem));
            yield return Row(ModifyValidReceiptItem(ri => { ri.Name = null; }));
            yield return Row(ModifyValidReceiptItem(ri => { ri.Name = ""; }));
            yield return Row(ModifyValidReceiptItem(ri => { ri.Name = " "; }));
            yield return Row(ModifyValidReceiptItem(ri => { ri.VatRateLetter = null; }));
            yield return Row(ModifyValidReceiptItem(ri => { ri.VatRateLetter = ""; }));
            yield return Row(ModifyValidReceiptItem(ri => { ri.VatRateLetter = " "; }));
        }

        private static FiscalReceiptItem ModifyValidReceiptItem(Action<FiscalReceiptItem> modify)
        {
            var receiptItem = FiscalReceiptTestData.ValidReceiptItem();
            modify(receiptItem);
            return receiptItem;
        }

        private static IEnumerable Row(params object[] parameters)
        {
            return parameters;
        }

    }
}

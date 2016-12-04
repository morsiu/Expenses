using System.Collections;
using System.Linq;
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

        public static IEnumerable InvalidReceiptItems()
        {
            return FiscalReceiptTestData.InvalidReceiptItems().Select(i => new[] { i });
        }
    }
}

using System.Linq;
using System.Collections;
using Mors.Expenses.Application.FiscalReceipts;
using Mors.Expenses.Data.Commands.Dtos;
using Xunit;

namespace Mors.Expenses.Application.Test.FiscalReceipts
{
    public static class FiscalReceiptValidatorUnitTest
    {
        [Fact]
        public static void Validate_Returns_True_Given_Valid_Receipt()
        {
            var isValid = FiscalReceiptValidator.Validate(FiscalReceiptTestData.ValidReceipt());
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
            return FiscalReceiptTestData.InvalidReceipts().Select(r => new object[] { r });
        }
    }
}

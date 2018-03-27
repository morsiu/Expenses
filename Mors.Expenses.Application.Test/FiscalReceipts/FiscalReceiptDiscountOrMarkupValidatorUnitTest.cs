using System.Collections.Generic;
using System.Linq;
using Mors.Expenses.Application.FiscalReceipts;
using Mors.Expenses.Data.Commands.Dtos;
using Xunit;

namespace Mors.Expenses.Application.Test.FiscalReceipts
{
    public class FiscalReceiptDiscountOrMarkupValidatorUnitTest
    {
        [Fact]
        public void Validate_Returns_True_For_Valid_Discount_Or_Markup()
        {
            Assert.True(FiscalReceiptDiscountOrMarkupValidator.Validate(FiscalReceiptTestData.ValidDiscountOrMarkup()));
        }

        [Theory]
        [MemberData("InvalidDiscountOrMarkups")]
        public void Validate_Returns_False_For_Invalid_Discount_Or_Markup(FiscalReceiptDiscountOrMarkup invalidDiscountOrMarkup)
        {
            Assert.False(FiscalReceiptDiscountOrMarkupValidator.Validate(invalidDiscountOrMarkup));
        }

        public static IEnumerable<object[]> InvalidDiscountOrMarkups()
        {
            return FiscalReceiptTestData.InvalidDiscountOrMarkups().Select(m => new[] {m});
        }
    }
}

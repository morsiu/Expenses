using System;
using System.Collections;
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
            Assert.True(FiscalReceiptDiscountOrMarkupValidator.Validate(ValidDiscountOrMarkup()));
        }

        [Theory]
        [MemberData("InvalidDiscountOrMarkups")]
        public void Validate_Returns_False_For_Invalid_Discount_Or_Markup(FiscalReceiptDiscountOrMarkup invalidDiscountOrMarkup)
        {
            Assert.False(FiscalReceiptDiscountOrMarkupValidator.Validate(invalidDiscountOrMarkup));
        }

        public static IEnumerable InvalidDiscountOrMarkups()
        {
            yield return Row(default(FiscalReceiptDiscountOrMarkup));
            yield return Row(ModifyValidDiscountOrMarkup(dm => { dm.Name = null; }));
            yield return Row(ModifyValidDiscountOrMarkup(dm => { dm.Name = ""; }));
            yield return Row(ModifyValidDiscountOrMarkup(dm => { dm.Name = " "; }));
            yield return Row(ModifyValidDiscountOrMarkup(dm => { dm.VatRateLetter = null; }));
            yield return Row(ModifyValidDiscountOrMarkup(dm => { dm.VatRateLetter = ""; }));
            yield return Row(ModifyValidDiscountOrMarkup(dm => { dm.VatRateLetter = " "; }));
        }

        private static FiscalReceiptDiscountOrMarkup ModifyValidDiscountOrMarkup(Action<FiscalReceiptDiscountOrMarkup> modify)
        {
            var discountOrMarkup = ValidDiscountOrMarkup();
            modify(discountOrMarkup);
            return discountOrMarkup;
        }

        private static IEnumerable Row(params object[] parameters)
        {
            return parameters;
        }

        public static FiscalReceiptDiscountOrMarkup ValidDiscountOrMarkup()
        {
            return new FiscalReceiptDiscountOrMarkup
            {
                Name = "Rabat JOG ZOT 370G +1ZA50%",
                Value = -1.88m,
                VatRateLetter = "D"
            };
        }
    }
}

using System;
using System.Collections;
using Mors.Expenses.Application.FiscalReceipts;
using Mors.Expenses.Data.Commands.Dtos;
using Xunit;

namespace Mors.Expenses.Application.Test.FiscalReceipts
{
    public class FiscalReceiptTotalValidatorUnitTest
    {
        [Fact]
        public void Validate_Returns_True_For_Valid_Total()
        {
            Assert.True(FiscalReceiptTotalValidator.Validate(FiscalReceiptTestData.ValidTotal()));
        }

        [Theory]
        [MemberData("InvalidTotals")]
        public void Validate_Returns_False_For_Invalid_Total(FiscalReceiptTotal invalidTotal)
        {
            Assert.False(FiscalReceiptTotalValidator.Validate(invalidTotal));
        }

        private static FiscalReceiptTotal ModifyValidTotal(Action<FiscalReceiptTotal> modify)
        {
            var total = FiscalReceiptTestData.ValidTotal();
            modify(total);
            return total;
        }

        public static IEnumerable InvalidTotals()
        {
            yield return Row(default(FiscalReceiptTotal));
            yield return Row(ModifyValidTotal(t => { t.VatRateLetter = null; }));
            yield return Row(ModifyValidTotal(t => { t.VatRateLetter = ""; }));
            yield return Row(ModifyValidTotal(t => { t.VatRateLetter = " "; }));
            yield return Row(ModifyValidTotal(t => { t.VatRatePercentValue = -4m; }));
        }

        private static IEnumerable Row(params object[] parameters)
        {
            return parameters;
        }
    }
}

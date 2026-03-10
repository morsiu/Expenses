using Mors.Expenses.Application.FiscalReceipts;
using Xunit;

namespace Mors.Expenses.Application.Test.FiscalReceipts
{
    public static class NipValidatorUnitTest
    {
        [Theory]
        [InlineData("9370008168")]
        [InlineData("93-70-008-168")]
        [InlineData("937-00-08-168")]
        public static void Validate_Returns_True_For_Valid_Nip(string nip)
        {
            Assert.True(NipValidator.Validate(nip));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1234567890123")]
        [InlineData("-------------")]
        [InlineData("----------")]
        [InlineData("1234567890")]
        [InlineData("0000000000")]
        public static void Validate_Returns_False_For_Invalid_Nip(string invalidNip)
        {
            Assert.False(NipValidator.Validate(invalidNip));
        }
    }
}

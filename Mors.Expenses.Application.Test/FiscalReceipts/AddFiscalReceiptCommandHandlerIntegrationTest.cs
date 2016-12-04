﻿using System.Collections;
using System.Linq;
using Mors.Expenses.Application.FiscalReceipts;
using Mors.Expenses.Data.Commands;
using Xunit;

namespace Mors.Expenses.Application.Test.FiscalReceipts
{
    public sealed class AddFiscalReceiptCommandHandlerIntegrationTest
    {
        [Theory]
        [MemberData("InvalidCommands")]
        public void Execute_Returns_False_Given_Invalid_Command(AddFiscalReceiptCommand command)
        {
            var handler = Handler();
            var result = handler.Execute(command, null);
            Assert.Equal(false, result);
        }

        [Fact]
        public void Execute_Returns_True_Given_Valid_Command()
        {
            var handler = Handler();
            var result = handler.Execute(ValidCommand(), null);
            Assert.Equal(true, result);
        }

        public static IEnumerable InvalidCommands()
        {
            yield return new[] { default(AddFiscalReceiptCommand) };
            foreach (var invalidReceipt in FiscalReceiptTestData.InvalidReceipts())
            {
                yield return new[] { new AddFiscalReceiptCommand { Receipt = invalidReceipt } };
            }
        }

        private static AddFiscalReceiptCommand ValidCommand()
        {
            return new AddFiscalReceiptCommand{ Receipt = FiscalReceiptTestData.ValidReceipt() };
        }

        private static AddFiscalReceiptCommandHandler Handler()
        {
            return new AddFiscalReceiptCommandHandler();
        }
    }
}

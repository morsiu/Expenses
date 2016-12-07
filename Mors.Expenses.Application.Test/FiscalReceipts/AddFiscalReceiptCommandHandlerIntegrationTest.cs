using System.Collections;
using Mors.Expenses.Application.FiscalReceipts;
using Mors.Expenses.Data.Commands;
using Mors.Expenses.Data.Events;
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
            var result = handler.Execute(command, new CommandEnvironmentDummy());
            Assert.Equal(false, result);
        }

        [Fact]
        public void Execute_Returns_True_Given_Valid_Command()
        {
            var handler = Handler();
            var result = handler.Execute(ValidCommand(), new CommandEnvironmentDummy());
            Assert.Equal(true, result);
        }

        [Fact]
        public void Execute_Publishes_FiscalReceiptAddedEvent_Given_Valid_Command()
        {
            var handler = Handler();
            var eventRecorder = new EventRecorder();
            handler.Execute(ValidCommand(), eventRecorder);
            eventRecorder.AssertRecordedEvent(e => e is FiscalReceiptAddedEvent);
        }

        [Theory]
        [MemberData("InvalidCommands")]
        public void Execute_Does_Not_Publish_Events_Given_Invalid_Command(AddFiscalReceiptCommand invalidCommand)
        {
            var handler = Handler();
            var eventRecorder = new EventRecorder();
            handler.Execute(invalidCommand, eventRecorder);
            eventRecorder.AssertRecordedNoEvents();
        }

        public sealed class FiscalReceiptAddedEventContentsTest
        {
            private readonly AddFiscalReceiptCommand _command;
            private readonly FiscalReceiptAddedEvent _event;

            public FiscalReceiptAddedEventContentsTest()
            {
                var handler = Handler();
                var eventRecorder = new EventRecorder();
                _command = ValidCommand();
                handler.Execute(_command, eventRecorder);
                _event = eventRecorder.FindEvent<FiscalReceiptAddedEvent>();
            }

            [Fact]
            public void Receipt()
            {
                Assert.NotNull(_event.Receipt);
            }

            [Fact]
            public void ReceiptTaxPayerName()
            {
                Assert.Equal(_command.Receipt.TaxPayerName, _event.Receipt.TaxPayerName);
            }

            [Fact]
            public void ReceiptTaxPayerAddress()
            {
                Assert.Equal(_command.Receipt.TaxPayerAddress, _event.Receipt.TaxPayerAddress);
            }

            [Fact]
            public void ReceiptTaxPayerNip()
            {
                Assert.Equal(_command.Receipt.TaxPayerNip, _event.Receipt.TaxPayerNip);
            }

            [Fact]
            public void ReceiptSalePlaceAddress()
            {
                Assert.Equal(_command.Receipt.AddressOfSalePlace, _event.Receipt.SalePlaceAddress);
            }

            [Fact]
            public void ReceiptSalePlaceName()
            {
                Assert.Equal(_command.Receipt.NameOfSalePlace, _event.Receipt.SalePlaceName);
            }

            [Fact]
            public void ReceiptTimeAndDateOfSale()
            {
                Assert.Equal(_command.Receipt.TimeAndDateOfSale, _event.Receipt.TimeAndDateOfSale);
            }

            [Fact]
            public void ReceiptGrossTotal()
            {
                Assert.Equal(_command.Receipt.GrossTotal, _event.Receipt.GrossTotal);
            }

            [Fact]
            public void ReceiptVatTotal()
            {
                Assert.Equal(_command.Receipt.VatTotal, _event.Receipt.VatTotal);
            }

            [Fact]
            public void ReceiptPaymentTotal()
            {
                Assert.Equal(_command.Receipt.PaymentTotal, _event.Receipt.PaymentTotal);
            }

            [Fact]
            public void ReceiptPaymentForm()
            {
                Assert.Equal(_command.Receipt.PaymentForm, _event.Receipt.PaymentForm);
            }

            [Fact]
            public void ReceiptCashPaymentChange()
            {
                Assert.Equal(_command.Receipt.CashPaymentChange, _event.Receipt.CashPaymentChange);
            }

            [Fact]
            public void ReceiptCurrencyCode()
            {
                Assert.Equal(_command.Receipt.CurrencyCode, _event.Receipt.CurrencyCode);
            }
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

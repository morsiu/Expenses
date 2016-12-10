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

            [Fact]
            public void ReceiptItems()
            {
                Assert.NotNull(_event.Receipt.Items);
            }

            [Fact]
            public void ReceiptItemCount()
            {
                Assert.Equal(_command.Receipt.Items.Count, _event.Receipt.Items.Count);
            }

            [Fact]
            public void ReceiptFirstItemAmount()
            {
                Assert.Equal(_command.Receipt.Items[0].Amount, _event.Receipt.Items[0].Amount);
            }

            [Fact]
            public void ReceiptFirstItemGrossValue()
            {
                Assert.Equal(_command.Receipt.Items[0].GrossValue, _event.Receipt.Items[0].GrossValue);
            }

            [Fact]
            public void ReceiptFirstItemName()
            {
                Assert.Equal(_command.Receipt.Items[0].Name, _event.Receipt.Items[0].Name);
            }

            [Fact]
            public void ReceiptFirstItemUnitGrossValue()
            {
                Assert.Equal(_command.Receipt.Items[0].UnitGrossValue, _event.Receipt.Items[0].UnitGrossValue);
            }

            [Fact]
            public void ReceiptFirstItemVatRateLetter()
            {
                Assert.Equal(_command.Receipt.Items[0].VatRateLetter, _event.Receipt.Items[0].VatRateLetter);
            }

            [Fact]
            public void ReceiptDiscountsAndMarkups()
            {
                Assert.NotNull(_event.Receipt.DiscountsAndMarkups);
            }

            [Fact]
            public void ReceiptDiscountsAndMarkupsCount()
            {
                Assert.Equal(_command.Receipt.DiscountsAndMarkups.Count, _event.Receipt.DiscountsAndMarkups.Count);
            }

            [Fact]
            public void ReceiptFirstDiscountAndMarkupName()
            {
                Assert.Equal(_command.Receipt.DiscountsAndMarkups[0].Name, _event.Receipt.DiscountsAndMarkups[0].Name);
            }

            [Fact]
            public void ReceiptFirstDiscountAndMarkupValue()
            {
                Assert.Equal(_command.Receipt.DiscountsAndMarkups[0].Value, _event.Receipt.DiscountsAndMarkups[0].Value);
            }

            [Fact]
            public void ReceiptFirstDiscountAndMarkupVatRateLetter()
            {
                Assert.Equal(_command.Receipt.DiscountsAndMarkups[0].VatRateLetter, _event.Receipt.DiscountsAndMarkups[0].VatRateLetter);
            }

            [Fact]
            public void ReceiptTotals()
            {
                Assert.NotNull(_event.Receipt.TotalsByVatRateLetter);
            }

            [Fact]
            public void ReceiptTotalsCount()
            {
                Assert.Equal(_command.Receipt.TotalsPerVatRate.Count, _event.Receipt.TotalsByVatRateLetter.Count);
            }

            [Fact]
            public void ReceiptFirstTotalVatRateLetter()
            {
                Assert.True(_event.Receipt.TotalsByVatRateLetter.ContainsKey(_command.Receipt.TotalsPerVatRate[0].VatRateLetter));
            }

            [Fact]
            public void ReceiptFirstTotalVatRateLetterPercent()
            {
                Assert.Equal(_command.Receipt.TotalsPerVatRate[0].VatRatePercentValue, _event.Receipt.TotalsByVatRateLetter[_command.Receipt.TotalsPerVatRate[0].VatRateLetter].VatRatePercentValue);
            }

            [Fact]
            public void ReceiptFirstTotalVatValue()
            {
                Assert.Equal(_command.Receipt.TotalsPerVatRate[0].VatValue, _event.Receipt.TotalsByVatRateLetter[_command.Receipt.TotalsPerVatRate[0].VatRateLetter].VatValue);
            }

            [Fact]
            public void ReceiptFirstTotalGrossValue()
            {
                Assert.Equal(_command.Receipt.TotalsPerVatRate[0].GrossValue, _event.Receipt.TotalsByVatRateLetter[_command.Receipt.TotalsPerVatRate[0].VatRateLetter].GrossValue);
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

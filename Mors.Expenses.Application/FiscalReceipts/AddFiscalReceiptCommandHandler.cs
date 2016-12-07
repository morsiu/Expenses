using Mors.Expenses.Data.Commands;
using Mors.Expenses.Data.Events;

namespace Mors.Expenses.Application.FiscalReceipts
{
    internal sealed class AddFiscalReceiptCommandHandler
    {
        public bool Execute(AddFiscalReceiptCommand command, ICommandEnvironment environment)
        {
            if (command == null || !FiscalReceiptValidator.Validate(command.Receipt))
            {
                return false;
            }
            environment.PublishEvent(
                new FiscalReceiptAddedEvent(
                    new Data.Events.Dtos.FiscalReceipt(
                        command.Receipt.TaxPayerName,
                        command.Receipt.TaxPayerAddress,
                        command.Receipt.TaxPayerNip,
                        command.Receipt.AddressOfSalePlace,
                        command.Receipt.NameOfSalePlace,
                        command.Receipt.TimeAndDateOfSale,
                        null,
                        null,
                        null,
                        command.Receipt.GrossTotal,
                        command.Receipt.VatTotal,
                        command.Receipt.PaymentTotal,
                        command.Receipt.PaymentForm,
                        command.Receipt.CashPaymentChange,
                        command.Receipt.CurrencyCode)));
            return true;
        }
    }
}

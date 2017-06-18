using System.Linq;
using Mors.Expenses.Data.Commands;
using Mors.Expenses.Data.Commands.Dtos;
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
                        command.Receipt.Number,
                        command.Receipt.TaxPayerName,
                        command.Receipt.TaxPayerAddress,
                        command.Receipt.TaxPayerNip,
                        command.Receipt.AddressOfSalePlace,
                        command.Receipt.NameOfSalePlace,
                        command.Receipt.TimeAndDateOfSale,
                        command.Receipt.Items.Select(ConvertItem).ToList(),
                        command.Receipt.DiscountsAndMarkups.Select(ConvertDiscountOrMarkup).ToList(),
                        command.Receipt.TotalsPerVatRate.ToDictionary(t => t.VatRateLetter, ConvertTotal),
                        command.Receipt.GrossTotal,
                        command.Receipt.VatTotal,
                        command.Receipt.PaymentTotal,
                        command.Receipt.PaymentForm,
                        command.Receipt.CashPaymentChange,
                        command.Receipt.CurrencyCode)));
            return true;
        }

        private Data.Events.Dtos.FiscalReceiptTotal ConvertTotal(FiscalReceiptTotal total)
        {
            return new Data.Events.Dtos.FiscalReceiptTotal(
                total.VatRateLetter,
                total.VatRatePercentValue,
                total.VatValue,
                total.GrossValue);
        }

        private Data.Events.Dtos.FiscalReceiptDiscountOrMarkup ConvertDiscountOrMarkup(FiscalReceiptDiscountOrMarkup discountOrMarkup)
        {
            return new Data.Events.Dtos.FiscalReceiptDiscountOrMarkup(
                discountOrMarkup.Name,
                discountOrMarkup.VatRateLetter,
                discountOrMarkup.Value);
        }

        private Data.Events.Dtos.FiscalReceiptItem ConvertItem(FiscalReceiptItem item)
        {
            return new Data.Events.Dtos.FiscalReceiptItem(
                item.Name,
                item.VatRateLetter,
                item.Amount,
                item.UnitGrossValue,
                item.GrossValue);
        }
    }
}

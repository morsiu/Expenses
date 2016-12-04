using Mors.Expenses.Data.Commands;

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
            return true;
        }
    }
}

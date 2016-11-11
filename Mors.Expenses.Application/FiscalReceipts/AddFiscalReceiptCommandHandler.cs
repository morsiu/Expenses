namespace Mors.Expenses.Application.FiscalReceipts
{
    internal sealed class AddFiscalReceiptCommandHandler
    {
        public void Execute(ICommandEnvironment environment)
        {
            // null collection == empty collection
            // null value == empty/missing value (string - empty, number - missing)

            // validation for receipt
            // non-empty tax payer, tax payer address, nip, currency code, payment form, sale place name, address
            // at least one item, total per vat rate
            // null or positive cash payment change

            // receipt item
            // non-empty name, vat rate letter
            // non -zero amount

            // discount/markup
            // non-empty name, vat rate letter

            // total
            // non-empty vat rate letter

            // nip validation
            // 10 digits: XXXXXXXXXX, XXX-XX-XX-XXX, XX-XX-XXX-XXX
            // check control digit

            // date and time validation
            // older than 01-01-2005

            // vat rate letter use validation
            // there is exactly one total for each vat letter used in items and markup/discounts
            // there is at least one item for each vat letter used in discounts/markups

            // value validation
            // grouped by each vat letter: sum of gross/vat of items and discounts/markups equals gross/vat of total within 0.01 error
            // receipt gross/vat equals sum of gross/vat totals, within 0.01 error

            // id creation
            // concatenation of tax payer nip as a number and date and time of sale
            // address of sale is excluded as it is unlikely for two sales to exist at the same time in different places

            // id validation
            // there are no two receipts with identical ids
        }
    }
}

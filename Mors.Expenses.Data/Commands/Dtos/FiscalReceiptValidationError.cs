namespace Mors.Expenses.Data.Commands.Dtos
{
    public enum FiscalReceiptValidationError
    {
        MissingFiscalReceipt,
        MissingTaxPayerName,
        MissingTaxPayerAddress,
        MissingTaxPayerNip,
        MissingAddressOfSalePlace,
        MissingNameOfSalePlace,
        MissingCurrencyCode,
        MissingPaymentForm,
        TimeAndDateOfSaleBeforeYear2005,
        InvalidTaxPayerNip
    }
}

using System.Runtime.Serialization;
using Mors.Expenses.Data.Commands.Dtos;

namespace Mors.Expenses.Data.Commands
{
    [DataContract]
    public class AddFiscalReceiptCommandResult
    {
        [DataMember]
        public FiscalReceiptValidationResult FiscalReceiptValidationResult { get; set; }
    }
}

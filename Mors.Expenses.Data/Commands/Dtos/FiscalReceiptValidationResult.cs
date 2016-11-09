using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mors.Expenses.Data.Commands.Dtos
{
    [DataContract]
    public class FiscalReceiptValidationResult
    {
        [DataMember]
        public IReadOnlyCollection<FiscalReceiptValidationError> ReceiptValidationErrors { get; set; }
    }
}

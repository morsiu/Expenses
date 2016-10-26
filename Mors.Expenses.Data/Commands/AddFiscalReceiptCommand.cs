using System.Runtime.Serialization;
using Mors.Expenses.Data.Commands.Dtos;

namespace Mors.Expenses.Data.Commands
{
    [DataContract]
    public class AddFiscalReceiptCommand
    {
        [DataMember]
        public FiscalReceipt Receipt { get; set; }
    }
}

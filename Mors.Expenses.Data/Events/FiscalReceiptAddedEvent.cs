using System.Runtime.Serialization;
using Mors.Expenses.Data.Events.Dtos;

namespace Mors.Expenses.Data.Events
{
    [DataContract]
    public sealed class FiscalReceiptAddedEvent
    {
        public FiscalReceiptAddedEvent(FiscalReceipt receipt)
        {
            Receipt = receipt;
        }

        [DataMember]
        public FiscalReceipt Receipt { get; }
    }
}

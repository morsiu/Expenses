using System.Runtime.Serialization;
using Mors.Expenses.Data.Commands.Dtos;

namespace Mors.Expenses.Data.Commands
{
    [DataContract]
    public class AddReceiptCommand
    {
        [DataMember]
        public Receipt Receipt { get; private set; }
    }
}

using Mors.Expenses.Data.Commands.Dtos;
using System.Windows.Input;
using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections;

namespace Mors.Expenses.Client.Wpf.Features.AddFiscalReceipt
{

    internal sealed class FiscalReceiptItemCollection : IEnumerable<FiscalReceiptItemViewModel>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public IReadOnlyList<FiscalReceiptItem> FiscalReceiptItems()
        {
            return null;
        }

        public bool Validate()
        {
            return false;
        }

        public void Clear()
        {
        }

        public IEnumerator<FiscalReceiptItemViewModel> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal sealed class FiscalReceiptDiscountAndMarkupCollection : IEnumerable<FiscalReceiptDiscountOrMarkupViewModel>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public IReadOnlyList<FiscalReceiptDiscountOrMarkup> FiscalReceiptDiscountsAndMarkups()
        {
            return null;
        }

        public bool Validate()
        {
            return false;
        }

        public void Clear()
        {
        }

        public IEnumerator<FiscalReceiptDiscountOrMarkupViewModel> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal sealed class FiscalReceiptTotalCollection : IEnumerable<FiscalReceiptTotalViewModel>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public IReadOnlyList<FiscalReceiptTotal> FiscalReceiptTotalsPerVatRate()
        {
            return null;
        }

        public bool Validate()
        {
            return false;
        }

        public void Clear()
        {
        }

        public IEnumerator<FiscalReceiptTotalViewModel> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal sealed class FiscalReceiptItemViewModel
    {
        public FiscalReceiptItem FiscalReceiptItem()
        {
            return null;
        }

        public bool Validate()
        {
            return false;
        }
    }

    internal sealed class FiscalReceiptDiscountOrMarkupViewModel
    {
        public FiscalReceiptDiscountOrMarkup FiscalReceiptDiscountOrMarkup()
        {
            return null;
        }

        public bool Validate()
        {
            return false;
        }
    }

    internal sealed class FiscalReceiptTotalViewModel
    {
        public FiscalReceiptTotal FiscalReceiptVatTotal()
        {
            return null;
        }

        public bool Validate()
        {
            return false;
        }
    }

    internal sealed class AddFiscalReceiptViewModel
    {
        public FiscalReceiptViewModel FiscalReceipt { get; }

        public ICommand AddFiscalReceiptCommand { get; }
    }

    internal sealed class AddFiscalReceiptCommand : ICommand
    {
        public AddFiscalReceiptCommand(FiscalReceiptViewModel fiscalReceipt)
        {
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}

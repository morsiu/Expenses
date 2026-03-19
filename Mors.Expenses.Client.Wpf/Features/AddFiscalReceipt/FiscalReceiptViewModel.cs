using Mors.Expenses.Data.Commands.Dtos;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mors.Expenses.Client.Wpf.Features.AddFiscalReceipt
{
    internal sealed class FiscalReceiptViewModel : INotifyPropertyChanged
    {
        public FiscalReceiptViewModel()
        {
            Items = new FiscalReceiptItemCollection();
            DiscountsAndMarkups = new FiscalReceiptDiscountAndMarkupCollection();
            Totals = new FiscalReceiptTotalCollection();
        }

        public FiscalReceipt FiscalReceipt()
        {
            return new FiscalReceipt
            {
                AddressOfSalePlace = _salePlaceAddress,
                CashPaymentChange = decimal.Parse(_cashPaymentChange),
                CurrencyCode = _currencyCode,
                DiscountsAndMarkups = DiscountsAndMarkups.FiscalReceiptDiscountsAndMarkups(),
                GrossTotal = decimal.Parse(_grossTotal),
                Items = Items.FiscalReceiptItems(),
                NameOfSalePlace = _salePlaceName,
                Number = _number,
                PaymentForm = _paymentForm,
                PaymentTotal = decimal.Parse(_paymentTotal),
                TaxPayerAddress = _taxPayerAddress,
                TaxPayerName = _taxPayerName,
                TaxPayerNip = _taxPayerNip,
                TimeAndDateOfSale = _dateOfSale.Add(TimeSpan.Parse(_timeOfSale)),
                TotalsPerVatRate = Totals.FiscalReceiptTotalsPerVatRate(),
                VatTotal = decimal.Parse(_vatTotal)
            };
        }

        public bool Validate()
        {
            return false;
        }

        public void Clear()
        {
            SalePlaceAddress = string.Empty;
            CashPaymentChange = string.Empty;
            CurrencyCode = string.Empty;
            DiscountsAndMarkups.Clear();
            GrossTotal = string.Empty;
            Items.Clear();
            SalePlaceName = string.Empty;
            Number = string.Empty;
            PaymentForm = string.Empty;
            PaymentTotal = string.Empty;
            TaxPayerAddress = string.Empty;
            TaxPayerName = string.Empty;
            TaxPayerNip = string.Empty;
            TimeOfSale = string.Empty;
            DateOfSale = default(DateTime);
            Totals.Clear();
            VatTotal = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public FiscalReceiptItemCollection Items { get; }

        public FiscalReceiptDiscountAndMarkupCollection DiscountsAndMarkups { get; }

        public FiscalReceiptTotalCollection Totals { get; }

        private string _salePlaceName;
        public string SalePlaceName
        {
            get { return _salePlaceName; }
            set
            {
                _salePlaceName = value;
                OnPropertyChanged();
            }
        }

        private string _salePlaceAddress;
        public string SalePlaceAddress
        {
            get { return _salePlaceAddress; }
            set
            {
                _salePlaceAddress = value;
                OnPropertyChanged();
            }
        }

        private string _taxPayerName;
        public string TaxPayerName
        {
            get { return _taxPayerName; }
            set
            {
                _taxPayerName = value;
                OnPropertyChanged();
            }
        }

        private string _taxPayerAddress;
        public string TaxPayerAddress
        {
            get { return _taxPayerAddress; }
            set
            {
                _taxPayerAddress = value;
                OnPropertyChanged();
            }
        }

        private string _taxPayerNip;
        public string TaxPayerNip
        {
            get { return _taxPayerNip; }
            set
            {
                _taxPayerNip = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dateOfSale;
        public DateTime DateOfSale
        {
            get { return _dateOfSale; }
            set
            {
                _dateOfSale = value;
                OnPropertyChanged();
            }
        }

        private string _vatTotal;
        public string VatTotal
        {
            get { return _vatTotal; }
            set
            {
                _vatTotal = value;
                OnPropertyChanged();
            }
        }

        private string _grossTotal;
        public string GrossTotal
        {
            get { return _grossTotal; }
            set
            {
                _grossTotal = value;
                OnPropertyChanged();
            }
        }

        private string _currencyCode;
        public string CurrencyCode
        {
            get { return _currencyCode; }
            set
            {
                _currencyCode = value;
                OnPropertyChanged();
            }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        private string _timeOfSale;
        public string TimeOfSale
        {
            get { return _timeOfSale; }
            set
            {
                _timeOfSale = value;
                OnPropertyChanged();
            }
        }

        private string _paymentForm;
        public string PaymentForm
        {
            get { return _paymentForm; }
            set
            {
                _paymentForm = value;
                OnPropertyChanged();
            }
        }

        private string _paymentTotal;
        public string PaymentTotal
        {
            get { return _paymentTotal; }
            set
            {
                _paymentTotal = value;
                OnPropertyChanged();
            }
        }

        private string _cashPaymentChange;
        public string CashPaymentChange
        {
            get { return _cashPaymentChange; }
            set
            {
                _cashPaymentChange = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

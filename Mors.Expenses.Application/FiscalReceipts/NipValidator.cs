using System.Linq;

namespace Mors.Expenses.Application.FiscalReceipts
{
    public static class NipValidator
    {
        private enum Format
        {
            Invalid,
            Numeric,
            NumericWithCitizenSeparators,
            NumericWithCompanySeparators
        }

        public static bool Validate(string nip)
        {
            var format = ValidateFormat(nip);
            if (format == Format.Invalid)
            {
                return false;
            }
            return ValidateControlDigit(nip, format);
        }

        private static Format ValidateFormat(string nip)
        {
            if (string.IsNullOrWhiteSpace(nip))
            {
                return Format.Invalid;
            }
            if (nip.Length == 10 && nip.All(IsDigit))
            {
                return Format.Numeric;
            }
            if (nip.Length == 13)
            {
                if (IsDigit(nip[0]) && IsDigit(nip[1]) && IsDigit(nip[2]) && IsSeparator(nip[3]) &&
                    IsDigit(nip[4]) && IsDigit(nip[5]) && IsSeparator(nip[6]) &&
                    IsDigit(nip[7]) && IsDigit(nip[8]) && IsSeparator(nip[9]) &&
                    IsDigit(nip[10]) && IsDigit(nip[11]) && IsDigit(nip[12]))
                {
                    return Format.NumericWithCompanySeparators;
                }
                if (IsDigit(nip[0]) && IsDigit(nip[1]) && IsSeparator(nip[2]) &&
                    IsDigit(nip[3]) && IsDigit(nip[4]) && IsSeparator(nip[5]) &&
                    IsDigit(nip[6]) && IsDigit(nip[7]) && IsDigit(nip[8]) && IsSeparator(nip[9]) &&
                    IsDigit(nip[10]) && IsDigit(nip[11]) && IsDigit(nip[12]))
                {
                    return Format.NumericWithCitizenSeparators;
                }
            }
            return Format.Invalid;
        }

        private static bool ValidateControlDigit(string nip, Format format)
        {
            var digits = nip.Where(IsDigit).Take(9).Select(ToNumber);
            var weights = new[] { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            var sum = digits.Zip(weights, (digit, weight) => digit * weight).Sum();
            var controlDigit = ToNumber(nip[nip.Length - 1]);
            return sum != 0 && (sum % 11) == controlDigit;
        }

        private static bool IsSeparator(char character)
        {
            return character == '-';
        }

        private static bool IsDigit(char character)
        {
            return character >= '0' && character <= '9';
        }

        private static int ToNumber(char digit)
        {
            return digit - '0';
        }
    }
}

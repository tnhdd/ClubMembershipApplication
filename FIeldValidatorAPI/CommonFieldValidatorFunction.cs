using System.Text.RegularExpressions;

namespace FIeldValidatorAPI
{
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
    public delegate bool PatternMatchDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);
    public class CommonFieldValidatorFunction
    {
        private static RequiredValidDel requiredValidel = null;
        private static StringLengthValidDel stringLengthValidDel = null;
        private static DateValidDel dateValidDel = null;
        private static PatternMatchDel patternMatchDel = null;
        private static CompareFieldsValidDel compareFieldsValidDel = null;

        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (requiredValidel == null)
                {
                    requiredValidel = new RequiredValidDel(RequiredFieldValid);
                }
                return requiredValidel;

            }
        }

        public static StringLengthValidDel StringLengthFieldValidDel
        {
            get
            {
                if (stringLengthValidDel == null)
                {
                    stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);
                }
                return stringLengthValidDel;

            }
        }

        public static DateValidDel DateFielValidDel
        {
            get
            {
                if (dateValidDel == null)
                {
                    dateValidDel = new DateValidDel(DateFieldValid);
                }
                return dateValidDel;

            }
        }


        public static PatternMatchDel PatternFieldMatchDel
        {
            get
            {
                if (patternMatchDel == null)
                {
                    patternMatchDel = new PatternMatchDel(FieldPatternValid);
                }
                return patternMatchDel;

            }
        }

        public static CompareFieldsValidDel FieldCompareValidDel
        {
            get
            {
                if (compareFieldsValidDel == null)
                {
                    compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonValid);
                }
                return compareFieldsValidDel;

            }
        }

        private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            return false;
        }

        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
            {
                return true;
            }
            return false;
        }

        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(dateTime, out validDateTime))
            {
                return true;
            }
            return false;
        }
        private static bool FieldPatternValid(string fieldVal, string regexPattern)
        {
            Regex regex = new Regex(regexPattern);
            if (regex.IsMatch(fieldVal)) { return true; }
            return false;
        }
        private static bool FieldComparisonValid(string field1, string field2)
        {
            if (field1.Equals(field2)) { return true; }
            return false;
        }

    }
}

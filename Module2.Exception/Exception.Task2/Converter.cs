using Exception.Task2.ConverterExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception.Task2
{
    public class Converter
    {
        private string originalValue;

        public Converter(string stringValue)
        {
            originalValue = stringValue;
        }

        public int ToInt()
        {
            return CheckWhetherNumberPositive() * GetNumberFromString();
        }

        private int CheckWhetherNumberPositive()
        {
            if (originalValue == null)
                throw new NullException("Incorrect format: the value is null.");
            else if (originalValue.Equals(string.Empty))
                throw new EmptyStringException("Incorrect Format: the value is empty.");
            else if (!CheckWhetherNumberDigital())
                throw new IncorrectFormatException("Incorrect Format: the value is not digital.");

            if (originalValue.ElementAt(0) == '-')
            {
                originalValue = originalValue.Remove(0, 1);
                return -1;
            }

            return 1;
        }

        private bool CheckWhetherNumberDigital()
        {
            if (originalValue.All(x => char.IsDigit(x)) ||
                    originalValue.ElementAt(0) == '-' && originalValue.Skip(1).All(x => char.IsDigit(x)))
            {
                return true;
            }

            return false;
        }

        private int GetNumberFromString()
        {
            return originalValue.Select(x => (int)char.GetNumericValue(x))
                .Select((x, i) => x * (int)Math.Pow(10, (originalValue.Count() - i - 1)))
                .Sum();
        }
    }
}

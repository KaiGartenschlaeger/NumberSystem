using System;
using System.Collections.Generic;
using System.Text;

namespace NumberSystem
{
    public class NumberConverter
    {
        #region Fields

        private readonly string _characters;
        private readonly int _base;

        #endregion

        #region Constructor

        public NumberConverter(string characters)
        {
            _characters = characters;
            _base = _characters.Length;
        }

        #endregion

        #region Helper

        private string RestValueToHexDigit(int value)
        {
            if (value + 1 > _base)
                throw new OverflowException();

            return _characters[value].ToString();
        }

        private int[] ToNumberArray(string value)
        {
            int[] result = new int[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                result[value.Length - i - 1] = _characters.IndexOf(value[i]);
                if (result[i] == -1)
                {
                    throw new ArgumentException(string.Format("Invalid character '{0}' detected at position '{1}'", value[i], i + 1), "value");
                }
            }

            return result;
        }

        #endregion

        #region Methods

        public string ToString(int value)
        {
            var rValues = new Stack<int>();
            while (true)
            {
                int q = value / _base;
                int r = value % _base;

                rValues.Push(r);

                value = q;
                if (value == 0)
                {
                    break;
                }
            }

            var response = new StringBuilder();
            while (rValues.Count > 0)
            {
                int r = rValues.Pop();
                response.Append(RestValueToHexDigit(r));
            }

            return response.ToString();
        }

        public int ToNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            int sum = 0;

            int[] numbers = ToNumberArray(value);
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i > 0)
                {
                    sum += (int)Math.Pow(_base, i) * numbers[i];
                }
                else
                {
                    sum += numbers[i];
                }
            }

            return sum;
        }

        #endregion

        #region Properties

        public int Base
        {
            get { return _base; }
        }

        public string Characters
        {
            get { return _characters; }
        }

        #endregion
    }
}
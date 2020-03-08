using System;
using System.Linq;
using Common.Cryptography.Interface;

namespace Common.Cryptography.Service
{
    public class Base32Service : IBase32Service
    {
        private readonly char[] _baseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567".ToCharArray();

        private readonly System.Collections.Generic.Dictionary<char, int> _charValues;

        public Base32Service()
        {
            _charValues = _baseChars
                .Select((c, i) => new { Char = c, Index = i })
                .ToDictionary(c => c.Char, c => c.Index);
        }

        public string LongToBase(long value)
        {
            long targetBase = _baseChars.Length;
            // Determine exact number of characters to use.
            var buffer = new char[Math.Max(
                (int)Math.Ceiling(Math.Log(value + 1, targetBase)), 1)];

            var i = buffer.Length;
            do
            {
                buffer[--i] = _baseChars[value % targetBase];
                value /= targetBase;
            }
            while (value > 0);

            return new string(buffer, i, buffer.Length - i);
        }

        public long BaseToLong(string cypherText)
        {
            var chrs = cypherText.ToCharArray();
            var m = chrs.Length - 1;
            var n = _baseChars.Length;
            return chrs.Select(t => _charValues[t]).Select(x => x * (long) Math.Pow(n, m--)).Sum();
        }
    }
}
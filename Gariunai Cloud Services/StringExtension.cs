using System;

namespace CustomExtensions
{
    public static class StringExtension
    {
        public static string NormalizeWhiteSpace(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var current = 0;
            var output = new char[input.Length];
            var skipped = false;

            foreach (var c in input.ToCharArray())
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!skipped)
                    {
                        if (current > 0)
                            output[current++] = ' ';

                        skipped = true;
                    }
                }
                else
                {
                    skipped = false;
                    output[current++] = c;
                }
            }

            return new string(output, 0, current);
        }
    }
}
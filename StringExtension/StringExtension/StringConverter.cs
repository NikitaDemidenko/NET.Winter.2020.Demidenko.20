using System;
using System.Text;
using System.Linq;

namespace StringExtension
{
    /// <summary>
    /// StringConverter.
    /// </summary>
    public static class StringConverter
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">source or count</exception>
        public static string Convert(string source, int count)
        {
            Validation(source, count);
            var result = new StringBuilder(source);

            for (int i = 0; i < count; i++)
            {
                RebuildString(result);

                if (result.ToString() == source)
                {
                    int newCount = count % (i + 1);
                    for (int j = 0; j < newCount; j++)
                    {
                        RebuildString(result);
                    }

                    break;
                }
            }

            return result.ToString();
        }

        private static void Validation(string source, int count)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            if (count <= 0)
            {
                throw new ArgumentException($"{nameof(count)} must be positive.");
            }
        }

        private static void RebuildString(StringBuilder source)
        {
            var evenLetters = new StringBuilder();
            var oddLetters = new StringBuilder();

            for (int i = 0; i < source.Length; i++)
            {
                if (i % 2 == 0) 
                { 
                    oddLetters.Append(source[i]); 
                }
                else 
                { 
                    evenLetters.Append(source[i]); 
                }
            }

            source.Clear();
            source.Append(oddLetters);
            source.Append(evenLetters);
        }
    }
}
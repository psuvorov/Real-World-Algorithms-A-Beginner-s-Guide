using System.Collections.Generic;
using System.Text;

namespace HuffmanDecoding
{
    public static class Decoder
    {
        // To decode coded string we need to have a legend table and bit sequence itself
        public static string Perform(Dictionary<string, char> codesToChars, string codedSequence)
        {
            var res = new StringBuilder();

            var codedSequenceChars = codedSequence.ToCharArray();
            var startIndex = 0;
            var endIndex = 0;

            while (endIndex <= codedSequenceChars.Length)
            {
                var occurrence = new string(codedSequenceChars, startIndex, endIndex - startIndex);
                if (codesToChars.ContainsKey(occurrence))
                {
                    res.Append(codesToChars[occurrence]);
                    startIndex += occurrence.Length;
                    endIndex = startIndex;
                }
                else
                {
                    endIndex++;
                }
            }

            return res.ToString();
        }
    }
}
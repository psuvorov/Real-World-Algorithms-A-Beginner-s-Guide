using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseCoding
{
    public static class Coder
    {
        
        private static Dictionary<char, string> MorseDictionary = new Dictionary<char, string>();
        
        public static string Perform(string message)
        {

            MorseDictionary = GetMorseDictionary();
            
            var res = new StringBuilder();

            message = message.ToLower();
            
            foreach (var c in message)
            {
                if (MorseDictionary.ContainsKey(c))
                {
                    var codedChar = MorseDictionary[c];
                    res.Append(codedChar).Append(" ");
                }
                else if (c == ' ')
                {
                    res.Append("/ ");
                }
            }

            return res.Remove(res.Length-1, 1).ToString();
        }
        
        public static Dictionary<char, string> GetCodingTable()
        {
            return MorseDictionary;
        }

        private static Dictionary<char, string> GetMorseDictionary()
        {
            return new Dictionary<char, string>()
            {
                {'a', ".-"},
                {'b', "-..."},
                {'c', "-.-."},
                {'d', "-.."},
                {'e', "."},
                {'f', "..-."},
                {'g', "--."},
                {'h', "...."},
                {'i', ".."},
                {'j', ".---"},
                {'k', "-.-"},
                {'l', ".-.."},
                {'m', "--"},
                {'n', "-."},
                {'o', "---"},
                {'p', ".--."},
                {'q', "--.-"},
                {'r', ".-."},
                {'s', "..."},
                {'t', "-"},
                {'u', "..-"},
                {'v', "...-"},
                {'w', ".--"},
                {'x', "-..-"},
                {'y', "-.--"},
                {'z', "--.."},
                {'0', "-----"},
                {'1', ".----"},
                {'2', "..---"},
                {'3', "...--"},
                {'4', "....-"},
                {'5', "....."},
                {'6', "-...."},
                {'7', "--..."},
                {'8', "---.."},
                {'9', "----."}
            };
        }
        
    }
}
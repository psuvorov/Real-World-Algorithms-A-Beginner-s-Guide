using Stack;

namespace CorrectBrackets
{
    public static class BracketChecker
    {
        public static bool IsCorrect(char[] terms)
        {
            int n = terms.Length;
            IStack<char> stack = new ArrayStack<char>(n);

            for (int i = 0; i < n; i++)
            {
                char t = terms[i];
                
                // Opening brackets:
                if (t == '(' || t == '{' || t == '[')
                {
                    stack.Push(t);
                }
                
                // Closing brackets
                if (t == ')')
                {
                    if (!stack.IsEmpty() && stack.Top() == '(')
                        stack.Pop();
                    else
                        return false;
                }
                else if (t == '}')
                {
                    if (!stack.IsEmpty() && stack.Top() == '{')
                        stack.Pop();
                    else
                        return false;
                }
                else if (t == ']')
                {
                    if (!stack.IsEmpty() && stack.Top() == '[')
                        stack.Pop();
                    else
                        return false;
                }
            }

            return stack.IsEmpty();
        }
    }
}
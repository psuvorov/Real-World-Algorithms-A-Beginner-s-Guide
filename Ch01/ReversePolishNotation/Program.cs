using System;
using Stack;

namespace ReversePolishNotation
{

    public static class ReversePolishNotationCalculator
    {
        public static int Calc(string[] terms)
        {
            int n = terms.Length;
            IStack<int> stack = new ArrayStack<int>(n);
            
            for (int i = 0; i < n; i++)
            {
                if (int.TryParse(terms[i], out int operand))
                {
                    stack.Push(operand);
                }
                else
                {
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();
                    switch (terms[i])
                    {
                        case "+":
                            stack.Push(operand1 + operand2);
                            break;
                        case "-":
                            stack.Push(operand1 - operand2);
                            break;
                        case "*":
                            stack.Push(operand1 * operand2);
                            break;
                        case "/":
                            stack.Push(operand1 / operand2);
                            break;
                    }
                }
            }

            return stack.Pop();
        }
    }
}
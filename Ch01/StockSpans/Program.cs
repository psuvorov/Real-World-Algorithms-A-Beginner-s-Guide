using System;
using System.Collections.Generic;
using System.Diagnostics;
using Stack;

namespace StockSpans
{
    public class Program
    {
        // Разница стоимостей акций в конкретный день — это число
        // следующих друг за другом дней, от выбранного нами и в обратном
        // направлении, до того дня, в который стоимость была меньше
        // или равна стоимости в выбранный нами день (т.е. ближайшее значение).
        


        public static IEnumerable<int> SimpleStockSpan(IReadOnlyList<int> quotes)
        {
            int n = quotes.Count;
            var spans = new int[n];
            for (var i = 0; i < n; i++)
            {
                int k = 1; // число дней назад
                bool spanEnd = false; // конец промежутка (встретилась цена больше текущего дня)
                while (i - k >= 0 && !spanEnd)
                {
                    if (quotes[i - k] <= quotes[i])
                    {
                        k++;
                    }
                    else
                    {
                        spanEnd = true;
                    }
                }

                spans[i] = k;
            }

            return spans;
        }

        // Каждый раз, когда мы возвращаемся в прошлое в поисках конца
        // отрезка, обозначающего разницу, нам нужно отбросить все дни со
        // значениями меньше или равными дню, в который мы высчитываем
        // разницу, и исключить отброшенные дни из последующего анализа.
        public static IEnumerable<int> StackStockSpan(IReadOnlyList<int> quotes)
        {
            int n = quotes.Count;
            var spans = new int[n];
            spans[0] = 1; // По умолчанию, цена в первый день равна единице
            
            IStack<int> stack = new ArrayStack<int>(n); // Используем стек, чтобы поместить в него все дни, которые нужно сравнить
            stack.Push(0); // Цена акций в первый день не ниже их цены в первый день
                
            for (var i = 1; i < n; i++)
            {
                while (!stack.IsEmpty() && quotes[stack.Top()] <= quotes[i])
                    stack.Pop();

                if (stack.IsEmpty())
                    spans[i] = i + 1;
                else
                    spans[i] = i - stack.Top();
                    
                stack.Push(i);
            }
            
            return spans;
        }
    }
}
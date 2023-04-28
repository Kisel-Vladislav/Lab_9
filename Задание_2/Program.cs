using System;
using System.Collections.Generic;

namespace Задание_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
                (2+3)(1+6)(((2-3)(5+1))) 
                2(3)(1+6(7+2))((2-3)(5+1)) 
                2(3+5(((6)))) 
                ((2+3)(4-1))) 
                2(3+5(((6))
            */
            while (true)
            {
                Console.Write("Математическое выражение: ");
                string mathExpression = Console.ReadLine();
                Stack<char> stack = new Stack<char>();
                bool corresponds = true;

                for (int i = 0; i < mathExpression.Length; i++)
                {
                    if (mathExpression[i] == '(')
                    {
                        stack.Push(mathExpression[i]);
                    }
                    else if (mathExpression[i] == ')')
                    {
                        if (stack.Count == 0)
                        {
                            corresponds = false;
                            break;
                        }
                        stack.Pop();
                    }
                        
                }

                if (corresponds && stack.Count == 0)
                    Console.WriteLine(true);
                else
                    Console.WriteLine(false);
            }
            
        }
    }
}

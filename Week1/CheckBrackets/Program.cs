using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringInput = Console.ReadLine();
            int errorKey = CheckBracketHasError(stringInput);
            if (errorKey != -1)
            {
                Console.WriteLine(errorKey + 1);
            }
            else
            {
                Console.WriteLine("Success");
            }
            
        }
        /// <summary>
        /// for every char has tow cases
        /// char
        /// opend open 
        ///     push into stack
        /// Closed one
        ///     if stack empty then error
        ///     if stsck.peek .has closed then error
        ///     if stack.peek has open with type diffrent from char then error
        ///     if stack.peek has open with type same char then continue 
        /// @ the end stack must be empty
        /// </summary>
        /// <param name="stringInput"></param>
        /// <returns></returns>
        private static int CheckBracketHasError(string stringInput)
        {
            Stack<KeyValuePair<char, int>> stack = new Stack<KeyValuePair<char, int>>();

            Dictionary<char, char> openDic = new Dictionary<char, char>();
            Dictionary<char, char> closeDic = new Dictionary<char, char>();
            openDic.Add('(', ')');
            openDic.Add('[', ']');
            openDic.Add('{', '}');
            closeDic.Add('}', '{');
            closeDic.Add(')', '(');
            closeDic.Add(']', '[');


            for (int i = 0; i < stringInput.Length; i++)
            {
                // closed one
                char closeDicValue;
                char openDicValue;
                if (closeDic.TryGetValue(stringInput[i], out closeDicValue))
                {
                    if (stack.Count == 0)
                    {
                        return i;
                    }
                    KeyValuePair<char, int> temp = stack.Pop();
                    /// open bracket                
                    if (openDic.TryGetValue(temp.Key, out  openDicValue))
                    {
                        // open and the same kind as closed one 
                        if (openDicValue == stringInput[i])
                        {
                            continue;
                        }
                        else
                        {  // open with diffrent kind
                            return i;
                        }
                    }
                    // close bracket
                    else
                    {
                        return i;
                    }
                }              
                else if (openDic.TryGetValue(stringInput[i], out  openDicValue ))
                {
                    stack.Push(new KeyValuePair<char, int>(stringInput[i], i));
                }
            }
            // ensure from 
            if (stack.Count != 0)
            {
                return stack.Pop().Value;
            }
            return -1;
        }
    }
}

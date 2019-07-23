using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Test2 = new int[] { 1, 1, 1, 1 };
            var result = binaryArrayToNumber(Test2);
            Console.WriteLine(result);
        }

        public static int binaryArrayToNumber(int[] BinaryArray)
        {
            int result = 0;
            int counter = 1;
            for (int i = BinaryArray.Length - 1; i >= 0; i--)
                {
                    result = result + BinaryArray[i] * counter;
                    counter = counter * 2;
                    Console.WriteLine(counter);
                    Console.WriteLine(BinaryArray[i]);
                }
            return result;
        }
    }
}

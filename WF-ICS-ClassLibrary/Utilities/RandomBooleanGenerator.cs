using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Utilities
{
    public static class RandomBooleanGenerator
    {
        private static readonly Random random = new Random();

        public static bool GetRandomBoolean()
        {
            return random.Next(2) == 0;
        }

        public static void Main()
        {
            bool result = GetRandomBoolean();
            Console.WriteLine($"Random boolean value: {result}");
        }
    }
}

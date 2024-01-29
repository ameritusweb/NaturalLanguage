using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcess
{
    public static class BinaryConverter
    {
        public static string Convert(int num)
        {
            byte[] bytes = BitConverter.GetBytes(num);
            string res = "";

            foreach (var b in bytes)
            {
                // Convert each byte to a binary string and pad with leading zeros
                res = System.Convert.ToString(b, 2).PadLeft(8, '0') + res;
            }

            var trimmed = res.TrimStart('0');

            return trimmed;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
    internal class UniqueLCGenerator
    {

    }
    class UniqueIDGenerator
    {
        //private const string Prefix = "STUD/";
        //private const int IdLength = 8;
        //private HashSet<string> generatedIds;
        //private Random random;

        //public UniqueIDGenerator()
        //{
        //    generatedIds = new HashSet<string>();
        //    random = new Random();
        //}

        //private string GenerateRandomNumberString(int length)
        //{
        //    char[] digits = new char[length];
        //    for (int i = 0; i < length; i++)
        //    {
        //        digits[i] = (char)('0' + random.Next(10));
        //    }
        //    return new string(digits);
        //}

        //public string GetNextUniqueId()
        //{
        //    string uniqueId;
        //    do
        //    {
        //        uniqueId = GenerateRandomNumberString(IdLength);
        //    } while (generatedIds.Contains(uniqueId));

        //    generatedIds.Add(uniqueId);
        //    return $"{Prefix}{uniqueId}";
        //}
    }
}

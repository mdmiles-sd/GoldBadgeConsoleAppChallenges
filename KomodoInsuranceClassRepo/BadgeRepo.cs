using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceClassRepo
{
    class BadgeRepo
    {
        private static Dictionary<int, object> dict;

        private static void Add(int intKey, object dataType)
        {
            if (!dict.ContainsKey(intKey))
            {
                dict.Add(intKey, dataType);
            }
            else
            {
                dict[intKey] = dataType;
            }
        }

        private static T GetAnyValue<T>(int strKey)
        {
            object obj;
            T retType;

            dict.TryGetValue(strKey, out obj);

            try
            {
                retType = (T)obj;
            }
            catch
            {
                retType = default(T);
            }
            return retType;
        }

        static void Main(int[] args)
        {
            dict = new Dictionary<int, object>();

            Add(12345, "A7");
            Add(22345, "A1,A4,B1,B2");
            Add(32345, "A4,A5");

            Console.WriteLine(12345 + GetAnyValue<string>(12345));
            Console.WriteLine(22345 + GetAnyValue<string>(22345));

            Console.ReadLine();
        }



    }
}


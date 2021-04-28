using System;

namespace TranzactTest.Shared
{
    public class Util
    {
        private static Util util;

        private Util()
        {

        }

        public static Util GetInstance()
        {
            if (util is null)
                util = new Util();

            return util;
        }

        public int[] ConverToIntArray(string numbers)
        {
            return Array.ConvertAll(numbers.Split(','), int.Parse);
        }
    }
}

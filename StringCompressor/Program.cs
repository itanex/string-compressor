using System;
using System.Linq;
using System.Text;

namespace StringCompressor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to string compression\n");

            var rawSortedString = GetGeneratedSortedString(150);

            Console.WriteLine("Attempting to compress the string:\n {0}\n", rawSortedString);

            var compressedStringResult = CompressSortedString(rawSortedString);

            if (compressedStringResult.compressed)
            {
                Console.WriteLine("The string was compressed: {0}", compressedStringResult.result);
                Console.ReadLine();
                return;
            }

            Console.WriteLine("The string is more optimized as it currently is.");
            Console.ReadLine();
        }

        /// <summary>
        /// Define other methods and classes here
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        static string GetGeneratedSortedString(int length)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            var sb = new StringBuilder(length);
            var rand = new Random(DateTime.Now.Millisecond);

            for (var i = 0; i < length; i++)
            {
                sb.Append(alphabet[rand.Next(0, alphabet.Length)]);
            }

            return sb.ToString();
        }

        static CompressResult CompressSortedString(string raw)
        {
            var result = new CompressResult() { result = raw };

            var attempt = new StringBuilder();

            var alphaGroups = raw.ToCharArray().GroupBy(x => x).ToArray();

            for (var i = 0; i < alphaGroups.Count(); i++)
            {
                attempt.AppendFormat("{0}{1}", alphaGroups[i].Key, alphaGroups[i].Count());
            }


            if (attempt.Length < raw.Length)
            {
                result.compressed = true;
                result.result = attempt.ToString();
            }

            return result;
        }
        
    }
}

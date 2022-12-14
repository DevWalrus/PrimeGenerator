using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;

namespace PrimeGenerator
{
    /// <summary>
    /// A set of helper functions and reference variables
    /// </summary>
    public static class Helpers
    {

        /// <summary>
        /// The first 100 prime numbers as defined in <a href="https://en.wikipedia.org/wiki/List_of_prime_numbers">
        /// Primes List</a>.
        /// </summary>
        public static readonly int[] FirstHPrimes =
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103,
            107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223,
            227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347,
            349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463,
            467, 479, 487, 491, 499, 503, 509, 521, 523, 541
        };
        
        /// <summary>
        /// The first 500 prime numbers as defined in <a href="https://en.wikipedia.org/wiki/List_of_prime_numbers">
        /// Primes List</a>.
        /// </summary>
        public static readonly int[] First5HPrimes =
        { 
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 
            107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 
            227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 
            349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 
            467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 
            613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 
            751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 
            887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013, 1019, 1021, 1031, 
            1033, 1039, 1049, 1051, 1061, 1063, 1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 
            1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 
            1291, 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373, 1381, 1399, 1409, 1423, 1427, 1429, 1433, 
            1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511,  1523, 1531, 1543, 1549, 1553, 
            1559, 1567, 1571, 1579, 1583, 1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657,  1663, 1667, 1669, 
            1693, 1697, 1699, 1709, 1721, 1723, 1733, 1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811,  1823, 
            1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889, 1901, 1907, 1913, 1931, 1933, 1949, 1951, 1973, 1979, 
            1987,  1993, 1997, 1999, 2003, 2011, 2017, 2027, 2029, 2039, 2053, 2063, 2069, 2081, 2083, 2087, 2089, 2099, 
            2111, 2113, 2129,  2131, 2137, 2141, 2143, 2153, 2161, 2179, 2203, 2207, 2213, 2221, 2237, 2239, 2243, 2251, 
            2267, 2269, 2273, 2281, 2287,  2293, 2297, 2309, 2311, 2333, 2339, 2341, 2347, 2351, 2357, 2371, 2377, 2381, 
            2383, 2389, 2393, 2399, 2411, 2417, 2423,  2437, 2441, 2447, 2459, 2467, 2473, 2477, 2503, 2521, 2531, 2539, 
            2543, 2549, 2551, 2557, 2579, 2591, 2593, 2609, 2617,  2621, 2633, 2647, 2657, 2659, 2663, 2671, 2677, 2683, 
            2687, 2689, 2693, 2699, 2707, 2711, 2713, 2719, 2729, 2731, 2741,  2749, 2753, 2767, 2777, 2789, 2791, 2797, 
            2801, 2803, 2819, 2833, 2837, 2843, 2851, 2857, 2861, 2879, 2887, 2897, 2903,  2909, 2917, 2927, 2939, 2953, 
            2957, 2963, 2969, 2971, 2999, 3001, 3011, 3019, 3023, 3037, 3041, 3049, 3061, 3067, 3079,  3083, 3089, 3109, 
            3119, 3121, 3137, 3163, 3167, 3169, 3181, 3187, 3191, 3203, 3209, 3217, 3221, 3229, 3251, 3253, 3257,  3259, 
            3271, 3299, 3301, 3307, 3313, 3319, 3323, 3329, 3331, 3343, 3347, 3359, 3361, 3371, 3373, 3389, 3391, 3407, 
            3413, 3433, 3449, 3457, 3461, 3463, 3467, 3469, 3491, 3499, 3511, 3517, 3527, 3529, 3533, 3539, 3541, 3547, 
            3557, 3559, 3571 
        };

        /// <summary>
        /// Uses the Miller-Rabin algorithm to test if an integer is prime or not. This also uses the BigInteger.ModPow
        /// function as it allows us to do a bit of mathematical optimization during the algorithm.
        /// </summary>
        /// <param name="n">The number we are testing</param>
        /// <param name="k">The number of rounds we are trying to perform (or witnesses)</param>
        /// <returns>False if the number is definitely composite, True otherwise (Note: This returns False if the
        /// algorithm found a composite factor in k witnesses, it is theoretically possible a factor slips through
        /// though it is mathematically improbable)</returns>
        public static Boolean IsProbablyPrime(this BigInteger n, int k = 10)
        {
            var r = 0;
            var d = n - 1;
            while (d % 2 == 0) // Factor out the possible 2's
            {
                d /= 2;
                r++;
            }

            var rng = RandomNumberGenerator.Create();
            for (int i = 0; i < k; i++)
            {
                var newBytes = new Byte[n.GetBitLength()/8];
                BigInteger a;
                do
                {
                    rng.GetBytes(newBytes);
                    a = new BigInteger(newBytes);
                } while (a < 2 || a > n - 2);

                var x = BigInteger.ModPow(a, d, n);
                if (x == 1 || x == n - 1)
                {
                    continue;
                }

                var witnessCont = false;
                for (int j = 0; j < r - 1; j++)
                {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == n - 1)
                    {
                        witnessCont = true;
                        break;
                    }
                }

                if (witnessCont) continue;
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// A class that generates a set of prime numbers that are <see cref="RandomNumberGenerator.GetBytes(byte[])">
    /// cryptographically strong</see>.
    /// </summary>
    public class PrimeGen
    {
        private RandomNumberGenerator _rng;

        /// <summary>
        /// Sets up the <see cref="RandomNumberGenerator">generator</see> to be used by <see cref="GeneratePrimes"/>.
        /// </summary>
        public PrimeGen()
        {
            _rng = RandomNumberGenerator.Create();
        }

        /// <summary>
        /// Generates a number of primes and outputs the numbers as they are generated. The total time it took to
        /// generate is also printed. 
        /// </summary>
        /// <param name="bits">The size (in bits) of the numbers to generate (usually). This might not be exact due to
        /// the possibility that the <see cref="RandomNumberGenerator.GetBytes(byte[])">generation process</see>
        /// could produce leading 0's</param>
        /// <param name="count">The number of primes to generate</param>
        public void GeneratePrimes(int bits, int count)
        {
            
            Console.WriteLine("BitLength: {0} bits", bits);

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (var i = 0; i < count; i++)
            {
                var prime = GeneratePrime(bits/8);
                Console.WriteLine("{0}: {1}", i + 1, prime);
            }
            stopwatch.Stop();
            Console.WriteLine("Time to Generate: {0}", stopwatch.Elapsed);
        }

        /// <summary>
        /// Generates 1 prime using many threads (Private Method)
        /// </summary>
        /// <param name="bytes">The size (in bytes) of the numbers to generate (usually). This might not be exact due to
        /// the possibility that the <see cref="RandomNumberGenerator.GetBytes(byte[])">generation process</see>
        /// could produce leading 0's</param>
        /// <returns>A number that is probably prime as defined <see cref="Helpers.IsProbablyPrime"/></returns>
        private BigInteger GeneratePrime(int bytes)
        {
            BigInteger result = 0;
            Parallel.For(0, Int64.MaxValue, (i, state) =>
            {
                BigInteger x;
                
                byte[] myBytes = new Byte[bytes];
                _rng.GetBytes(myBytes);
                x = BigInteger.Abs(new BigInteger(myBytes));

                foreach (var prime in Helpers.First5HPrimes)
                {
                    if (x % prime == 0)
                    {
                        return;
                    }
                }

                if (x.IsProbablyPrime())
                {
                    result = x;
                    state.Stop();
                }
            });
            return result;
        }

        /// <summary>
        /// Outputs a help message whenever a command line argument is incorrect or improperly formatted.
        /// </summary>
        public static void HelpMsg()
        {
            Console.WriteLine("Usage: PrimeGen <bits> <count=1>\n" +
                              "\t- bits - the number of bits of the prime number, this must be a\n" + 
                              "\t  multiple of 8, and at least 32 bits.\n" + 
                              "\t- count - the number of prime numbers to generate, defaults to 1");
        }
        
        /// <summary>
        /// A program that parses the arguments that were passed in and generates a number of primes, by default 1, of a
        /// provided size. The arguments are defined in <see cref="HelpMsg"/>>.The program has 3 defined exit codes:
        /// <list type="table">
        ///     <listheader>
        ///         <term>Exit Code</term>
        ///         <description>Meaning</description>
        ///     </listheader>
        ///     <item>
        ///         <term>0</term>
        ///         <description>Success</description>
        ///     </item>
        ///     <item>
        ///         <term>1</term>
        ///         <description>Incorrect number of args provided</description>
        ///     </item>
        ///     <item>
        ///         <term>2</term>
        ///         <description>The provided argument(s) were not integers</description>
        ///     </item>
        ///     <item>
        ///         <term>3</term>
        ///         <description>The provided bit length was not larger than 32 or it was not a multiple of 8
        ///         </description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="args">Arguments as they are defined in <see cref="HelpMsg"/></param>
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                HelpMsg();
                Environment.Exit(1);
            }

            int bits = 0, count = 0;
            
            try
            {
                bits = int.Parse(args[0]);
                count = args.Length > 1 ? int.Parse(args[1]) : 1;
                if (bits % 8 != 0 || bits < 32)
                {
                    HelpMsg();
                    Environment.Exit(3);
                }
            }
            catch
            {
                HelpMsg();
                Environment.Exit(2);
            }
            
            new PrimeGen().GeneratePrimes(bits, count);
            
        }
    }
}
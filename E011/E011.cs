/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * 
 * Project Euler Tribute Problem I created
 * In the given file, data.txt, what is the largest prime number consisting of all prime digits? 
 */

using System;

namespace e011 {
    class E011 {
        public static long SolveWithBigInt() {
            throw new Exception("Not implemented");
            String[] lines = System.IO.File.ReadAllLines(@"../../Data/data.txt");
            long maxPrime = 0, num = 0;
            String tmp = "", numString = "";
            foreach (String s in lines) {
                for (int i = 0; i < s.Length; i++) {
                    tmp = s.Substring(i);
                    for (int j = 1; j <= tmp.Length; j++) {
                        numString = tmp.Substring(0, j);
                        Console.WriteLine(numString);

                        num = Convert.ToInt64(numString);
                        if (IsPrime(num)) { if (num > maxPrime) { maxPrime = num; } }
                    }
                }
            }
            return maxPrime;
        }
        public static long Solve() {
            String[] lines = System.IO.File.ReadAllLines(@"../../Data/data.txt");
            long maxPrime = 0, num = 0;
            String tmp = "", numString = "";
            foreach (String s in lines) {
                Boolean keepGoing;
                for (int i = 0; i < s.Length; i++) {
                    tmp = s.Substring(i);
                    keepGoing = true;
                    for (int j = 1; j <= tmp.Length && keepGoing; j++) {
                        numString = tmp.Substring(0, j);
//                      Console.WriteLine(numString);
                        if (IsPrime(Convert.ToInt32(numString.Substring(numString.Length - 1, 1)))) {
                            num = Convert.ToInt64(numString);
                            if (IsPrime(num)) {
                                if (num > maxPrime) {
                                  Console.WriteLine("Replacing " + maxPrime + " with " + num);
                                    maxPrime = num;
                                }
                            } else {
                                // Give up on this starting point in the string
//                                keepGoing = false;
                            }
                        } else { keepGoing = false; }
                    }
                }
            }
            return maxPrime;
        }
        private static Boolean IsPrime(long num) {
            if (num == 2) return true;
            if (num % 2 == 0) return false;
            long limit = (int)Math.Sqrt(num);
            for (long i = 3; i < limit; i++) {
                if (num % i == 0) { return false; }
            }
            return true;
        }
/*        private static Boolean IsPrime(BigInteger num) {
            if (num == 2) return true;
            long limit = (int)Math.Sqrt(num);
            for (long i = 3; i < limit; i++) {
                if (num % i == 0) { return false; }
            }
            return true;
        } */
    }
}

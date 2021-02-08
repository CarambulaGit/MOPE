using System;

namespace MOPEUtils {
    public static class RandomExtension {
        public static float Range(this Random random, float randomMin, float randomMax) {
            return (float) random.NextDouble() * (randomMax - randomMin) + randomMin;
        }
    }

    public static class ArrayExtension {
        public static void Print<T>(this T[][] arr) {
            foreach (var row in arr) {
                foreach (var element in row) {
                    Console.Write($"{element} \t");
                }

                Console.WriteLine();
            }
        }
        public static void PrintRevert<T>(this T[][] arr) {
            for (var j = 0; j < arr[0].Length; j++) {
                foreach (var column in arr) {
                    Console.Write($"{column[j]} \t");
                }

                Console.WriteLine();
            }
        }
    }
    
    public static class ListExtension {
    
    }
}
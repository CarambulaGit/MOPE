using System;
using System.Collections.Generic;

namespace MOPEUtils {
    public static class RandomExtension {
        public static float Range(this Random random, float randomMin, float randomMax) {
            return (float) random.NextDouble() * (randomMax - randomMin) + randomMin;
        }
    }

    public static class ArrayExtension {
        public static void PrintLine<T>(this T[][] arr, int rowIndex, bool isFloat = false) {
            for (var j = 0; j < arr[rowIndex].Length; j++) {
                Console.Write(isFloat ? $"{arr[rowIndex][j]:f} \t" : $"{arr[rowIndex][j]} \t");
            }
        }

        public static void Print<T>(this T[][] arr, bool isFloat = false) {
            for (var i = 0; i < arr.Length; i++) {
                PrintLine(arr, i, isFloat);
                Console.WriteLine();
            }
        }

        public static void PrintRevert<T>(this T[][] arr, bool isFloat = false) {
            for (var j = 0; j < arr[0].Length; j++) {
                foreach (var column in arr) {
                    Console.Write(isFloat ? $"{column[j]} \t" : $"{column[j]:f} \t");
                }

                Console.WriteLine();
            }
        }
    }

    // public static class ListExtension {
    //     public static void PrintTable<T>(this List<T[][]> table) {
    //         for (var i = 0; i < table[0].Length; i++) {
    //             foreach (var category in table) {
    //                 category.PrintLine(i);
    //             }
    //         }
    //
    //         Console.WriteLine();
    //     }
    // }
}
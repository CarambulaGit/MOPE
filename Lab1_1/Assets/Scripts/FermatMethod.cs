using System;
using System.Collections.Generic;
using UnityEngine;

public static class FermatMethod {
    private const string TOO_MUCH_TIME = "Operation too long";
    private const string N_EVEN = "N must be odd";
    private const string N_MUST_BE_GREATER_THEN_1 = "N must be greater than 1";
    private const int MAX_OPERATION_TIME = 30;

    public static long[] Factorize(long n) {
        if (n % 2 == 0) {
            throw new Exception(N_EVEN);
        }
        
        if (n <= 1) {
            throw new Exception(N_MUST_BE_GREATER_THEN_1);
        }

        var multipliers = new List<long>();
        var sqrts = GetSumOfSquares(n, var numOfOperations);
        Debug.Log(numOfOperations);
        multipliers.Add(Math.Abs(sqrts[0] + sqrts[1]));
        multipliers.Add(Math.Abs(sqrts[0] - sqrts[1]));

        return multipliers.ToArray();
    }

    private static long[] GetSumOfSquares(long n, out int numOfOperations) {
        double x, y;
        numOfOperations = 0

        x = Math.Ceiling(Math.Sqrt(n));
        y = Math.Pow(x, 2) - n;

        while (Math.Abs(Math.Sqrt(y) - Math.Ceiling(Math.Sqrt(y))) > 0.0001f) {
        	numOfOperations++;
            x++;
            y = Math.Pow(x, 2) - n;


            if (Time.deltaTime >= MAX_OPERATION_TIME) throw new Exception(TOO_MUCH_TIME);
        }

        return new[] {(long) x, (long) Math.Sqrt(y)};
    }
}
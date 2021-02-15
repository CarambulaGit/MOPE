using System;
using System.Collections.Generic;
using System.Linq;
using MOPEUtils;

namespace Lab1 {
    class Lab1 {
        private const int SECOND_DIMENSION_LENGTH = 8;
        private float[][] experiments;
        private float[][] experimentsNormalized;
        private float[] aArr = new float[4];
        private float[] yArr;
        private float[] x0Arr;
        private float[] dxArr;
        private float y0;
        private float randomMin;
        private float randomMax;
        private Random randomizer;

        public Lab1(float[][] experiments, float a0, float a1, float a2, float a3, float randomMin, float randomMax) {
            this.experiments = experiments;
            experimentsNormalized = new float[this.experiments.Length][];
            for (var i = 0; i < experiments.Length; i++) {
                experiments[i] = new float[SECOND_DIMENSION_LENGTH];
                experimentsNormalized[i] = new float[SECOND_DIMENSION_LENGTH];
            }

            yArr = new float[SECOND_DIMENSION_LENGTH];
            x0Arr = new float[experiments.Length];
            dxArr = new float[experiments.Length];
            aArr[0] = a0;
            aArr[1] = a1;
            aArr[2] = a2;
            aArr[3] = a3;
            this.randomMin = randomMin;
            this.randomMax = randomMax;
            randomizer = new Random();
        }

        private void InitExperiments() {
            for (var i = 0; i < experiments.Length; i++) {
                for (var j = 0; j < experiments[i].Length; j++) {
                    experiments[i][j] = randomizer.Range(randomMin, randomMax);
                }
            }
        }

        private void FillYArray() {
            for (var i = 0; i < yArr.Length; i++) {
                yArr[i] = aArr[0] +
                          aArr[1] * experiments[0][i] + aArr[2] * experiments[1][i] + aArr[3] * experiments[2][i];
            }
        }

        private void FillX0Array() {
            for (var i = 0; i < x0Arr.Length; i++) {
                x0Arr[i] = (experiments[i].Max() + experiments[i].Min()) / 2;
            }
        }

        private void FillDxArray() {
            for (var i = 0; i < dxArr.Length; i++) {
                dxArr[i] = x0Arr[i] - experiments[i].Min();
            }
        }

        private void FillNormalize() {
            for (var i = 0; i < experimentsNormalized.Length; i++) {
                for (var j = 0; j < experimentsNormalized[0].Length; j++) {
                    experimentsNormalized[i][j] = (experiments[i][j] - x0Arr[i]) / dxArr[i];
                }
            }
        }

        private void FindY0() {
            y0 = aArr[0] +
                 aArr[1] * x0Arr[0] + aArr[2] * x0Arr[1] + aArr[3] * x0Arr[2];
        }

        private float FindYWhichSatisfiesCriterion() {
            var average = yArr.Average();
            var localYArr = yArr.Select(y => y - average).ToList();
            return localYArr.Where(y => y >= 0).Min() + average;
        }

        private List<float[]> FindListOfFactsWhichGenYByCrit(float yByCriterion) {
            var listOfFactors = new List<float[]>();
            for (var j = 0; j < experimentsNormalized[0].Length; j++) {
                if (yArr[j].Equals(yByCriterion)) {
                    listOfFactors.Add(new[]
                        {experimentsNormalized[0][j], experimentsNormalized[1][j], experimentsNormalized[2][j]});
                }
            }

            return listOfFactors;
        }

        public List<float[]> RunExperiment() {
            InitExperiments();
            FillYArray();
            FillX0Array();
            FillDxArray();
            FillNormalize();
            FindY0();
            var y = FindYWhichSatisfiesCriterion();
            return FindListOfFactsWhichGenYByCrit(y);
        }

        private static void Main(string[] args) {
            var sol = new Lab1(new float[3][], 1, 2, 3, 4, 0, 20);
            sol.RunExperiment().ToArray().Print(true);
            Console.WriteLine();
            sol.experiments.Print(true);
            Console.WriteLine();
            new[] {sol.yArr}.Print(true);
            Console.WriteLine();
            sol.experimentsNormalized.Print(true);
        }
    }
}
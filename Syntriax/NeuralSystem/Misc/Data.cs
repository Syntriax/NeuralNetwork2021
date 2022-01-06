using System;
using System.Collections.Generic;

namespace Syntriax.NeuralNetwork.Misc
{
    public class Data
    {
        public int InputCount => trainInput[0].Length;
        public int OutputCount => trainOutput[0].Length;
        public List<double[]> trainInput { get; private set; } = null;
        public List<double[]> trainOutput { get; private set; } = null;
        public List<double[]> testInput { get; private set; } = null;
        public List<double[]> testOutput { get; private set; } = null;

        public Data(List<double[]> data, int inputCount, double trainRatio = 0.2, int? seed = null)
        {
            int indexToSwap = 0;
            int count = data.Count;
            int testCount = (int)(count * trainRatio);
            Random random = new Random(seed ?? 0);

            double[] inputArray = null;
            double[] outputArray = null;

            trainInput = new List<double[]>(count - testCount);
            trainOutput = new List<double[]>(count - testCount);
            testInput = new List<double[]>(testCount);
            testOutput = new List<double[]>(testCount);

            for (int i = 0; i < count; i++)
            {
                indexToSwap = random.Next(i, count);
                (data[i], data[indexToSwap]) = (data[indexToSwap], data[i]);
            }

            for (int i = 0; i < count; i++)
            {
                (inputArray, outputArray) = SplitData(data[i], inputCount);
                if (i < testCount)
                {
                    testInput.Add(inputArray);
                    testOutput.Add(outputArray);
                }
                else
                {
                    trainInput.Add(inputArray);
                    trainOutput.Add(outputArray);
                }
            }
        }
        public Data(List<double[]> train, List<double[]> test, int inputCount, double trainRatio = 0.2)
        {
            double[] inputArray = null;
            double[] outputArray = null;

            trainInput = new List<double[]>(train.Count);
            trainOutput = new List<double[]>(train.Count);
            testInput = new List<double[]>(test.Count);
            testOutput = new List<double[]>(test.Count);

            for (int i = 0; i < train.Count; i++)
            {
                (inputArray, outputArray) = SplitData(train[i], inputCount);
                trainInput.Add(inputArray);
                trainOutput.Add(outputArray);
            }

            for (int i = 0; i < test.Count; i++)
            {
                (inputArray, outputArray) = SplitData(test[i], inputCount);
                testInput.Add(inputArray);
                testOutput.Add(outputArray);
            }
        }

        private (double[] inputArray, double[] outputArray) SplitData(double[] array, int inputCount)
        {
            int outputCount = array.Length - inputCount + 1;
            int i = 0;
            double[] input = new double[inputCount];
            double[] output = new double[outputCount];

            for (i = 0; i < array.Length; i++)
                if (i >= inputCount)
                    output[i - inputCount] = array[i];
                else
                    input[i] = array[i];

            return (input, output);
        }
    }
}

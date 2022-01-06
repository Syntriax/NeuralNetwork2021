// using System;

// namespace Syntriax.NeuralNetwork.Misc
// {
//     public class DataNew
//     {
//         public int InputCount => trainInput.GetLength(0);
//         public int OutputCount => trainOutput.GetLength(0);
//         public double[,] trainInput { get; private set; } = null;
//         public double[,] trainOutput { get; private set; } = null;
//         public double[,] testInput { get; private set; } = null;
//         public double[,] testOutput { get; private set; } = null;

//         public DataNew(double[,] data, int inputCount, double testRatio = 0.2, int? seed = null)
//         {
//             int attributeCount = data.GetLength(1);
//             int dataCount = data.GetLength(0);
//             int testCount = (int)(dataCount * testRatio);
//             int trainCount = dataCount - testCount;

//             double[,] trainData = new double[trainCount, attributeCount];
//             double[,] testData = new double[testCount, attributeCount];

//             if (seed != null)
//                 Shuffle(data, attributeCount, new Random(seed.Value));

//             int i = 0;
//             int a = 0;
//             for (i = 0; i < dataCount; i++)
//                 for (a = 0; a < attributeCount; a++)


//         }

//         private void Shuffle(double[,] data, int attributeCount, Random random)
//         {
//             int indexToSwap = 0;
//             int length = data.Length;
//             int i = 0;
//             int a = 0;

//             for (i = 0; i < length; i++)
//             {
//                 indexToSwap = random.Next(i, length);
//                 for (a = 0; a < attributeCount; a++)
//                     (data[i, a], data[indexToSwap, a]) = (data[indexToSwap, a], data[i, a]);
//             }
//         }

//         public DataNew(double[,] train, double[,] test, int inputCount)
//         {
//             int attributeCount = train.GetLength(1);
//             int attributeInputCount = inputCount;
//             int attributeOutputCount = attributeCount - attributeInputCount;

//             int trainCount = train.GetLength(0);
//             int testCount = test.GetLength(0);

//             trainInput = new double[train.GetLength(0), attributeInputCount];
//             trainOutput = new double[train.GetLength(0), attributeOutputCount];
//             testInput = new double[test.GetLength(0), attributeInputCount];
//             testOutput = new double[test.GetLength(0), attributeOutputCount];

//             SplitIntoAttributeArrays(train, trainInput, trainOutput, trainCount, attributeInputCount, attributeOutputCount);
//             SplitIntoAttributeArrays(test, testInput, testOutput, testCount, attributeInputCount, attributeOutputCount);
//         }

//         private void SplitIntoAttributeArrays(double[,] source, double[,] inputDestination, double[,] outputDestination,
//             int count, int inputCount, int outputCount)
//         {
//             int i = 0;
//             int j = 0;

//             for (i = 0; i < count; i++)
//             {
//                 for (j = 0; j < inputCount; j++)
//                     inputDestination[i, j] = source[i, j];
//                 for (j = 0; j < outputCount; j++)
//                     outputDestination[i, j] = source[i, j + inputCount];
//             }
//         }
//     }
// }

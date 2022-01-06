using System;
using System.Linq;
using Syntriax.NeuralNetwork;
using Syntriax.NeuralNetwork.Misc;
using Syntriax.NeuralNetwork.NeuronActivations;

namespace NeuralNetwork2021
{
    class Program
    {
        static void Main(string[] args)
        {
            const int epochCount = 5000;
            const int epochPrintInterval = 1;

            const int dataSeed = 10;
            const int weightSeed = 0;
            const int dropoutSeed = 0;
            DropoutNeuronDecorator.Random = new Random(dropoutSeed);

            double learningRate = 0.001;

            Data data = new Data(DataTest.LoadData().ToList(), 4, seed: dataSeed);

            NeuralNetwork neuralNetwork = new NeuralNetwork
            (
                data.InputCount,
                new int[] { 10 },
                data.OutputCount
            );

            foreach (LayerBase layer in neuralNetwork.GetLayerList())
                layer.SetActivation(StaticActivation<Relu>.Instance);
            // neuralNetwork.outputLayer.SetActivation(StaticActivation<Relu>.Instance);

            neuralNetwork.Randomize(weightSeed);

            for (int k = 0; k < epochCount; k++)
            {
                if (k % epochPrintInterval == 0)
                    Console.WriteLine($"Epoch: {k}\tHata: { neuralNetwork.GetTotalError(data) }");

                neuralNetwork.Train(data, learningRate);
            }
            Console.WriteLine($"Hata: { neuralNetwork.GetTotalError(data) }");
        }
    }
}

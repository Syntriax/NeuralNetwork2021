using System;
using System.Collections.Generic;
using Syntriax.NeuralNetwork.Misc;

namespace Syntriax.NeuralNetwork
{
    public static class NeuralNetworkExtensions
    {
        public static List<LayerBase> GetLayerList(this NeuralNetwork neuralNetwork)
        {
            List<LayerBase> layers = new List<LayerBase>(2 + neuralNetwork.hiddenLayers.Length);

            layers.Add(neuralNetwork.inputLayer);
            layers.AddRange(neuralNetwork.hiddenLayers);
            layers.Add(neuralNetwork.outputLayer);

            return layers;
        }

        public static List<INeuron> GetNeuronList(this NeuralNetwork neuralNetwork)
        {
            int neuronCount = 0;
            List<LayerBase> layers = neuralNetwork.GetLayerList();

            foreach (LayerBase layer in layers)
                neuronCount += layer.neurons.Length;

            List<INeuron> neurons = new List<INeuron>(neuronCount);

            foreach (LayerBase layer in layers)
                neurons.AddRange(layer.neurons);

            return neurons;
        }

        public static List<ISynapse> GetSynapseList(this NeuralNetwork neuralNetwork)
        {
            int synapseCount = 0;
            List<INeuron> neurons = neuralNetwork.GetNeuronList();

            foreach (INeuron neuron in neurons)
                synapseCount += neuron.Synapses.Length + 1; // + 1 for the bias

            List<ISynapse> synapses = new List<ISynapse>(synapseCount);

            foreach (INeuron neuron in neurons)
            {
                synapses.AddRange(neuron.Synapses);
                synapses.Add(neuron.Bias);
            }

            return synapses;
        }

        /* ------------------------------------------------------------- */

        public static void Randomize(this NeuralNetwork neuralNetwork, int? seed = null)
        {
            Random random = new Random(seed ?? 0);

            foreach (ISynapse synapse in neuralNetwork.GetSynapseList())
                synapse.Weight = random.NextDouble();
        }

        /* ------------------------------------------------------------- */

        public static void SetInput(this NeuralNetwork neuralNetwork, int neuronIndex, double value)
        {
            InputNeuron inputNeuron = (InputNeuron)neuralNetwork.inputLayer.neurons[neuronIndex];
            inputNeuron.Value = value;
        }
        public static void SetInputs(this NeuralNetwork neuralNetwork, double[] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
                neuralNetwork.SetInput(i, inputs[i]);
        }

        public static double GetOutput(this NeuralNetwork neuralNetwork, int neuronIndex) =>
            neuralNetwork.outputLayer.neurons[neuronIndex].Output;


        /* ------------------------------------------------------------- */

        public static double GetErrorOfNeuron(NeuralNetwork neuralNetwork, double[] output, int i) =>
            output[i] - neuralNetwork.GetOutput(i);

        public static double[] GetErrors(this NeuralNetwork neuralNetwork, double[] outputs)
        {
            int length = neuralNetwork.outputLayer.neurons.Length;
            double[] result = new double[length];
            for (int i = 0; i < length; i++)
                result[i] = GetErrorOfNeuron(neuralNetwork, outputs, i);
            return result;
        }

        public static double GetTotalError(this NeuralNetwork neuralNetwork, Data data)
        {
            double totalError = 0.0f;
            double[] errors = null;

            for (int i = 0; i < data.testInput.Count; i++)
            {
                neuralNetwork.SetInputs(data.testInput[i]);
                neuralNetwork.FireNetwork();

                errors = neuralNetwork.GetErrors(data.testOutput[i]);

                foreach (double error in errors)
                    totalError += error * error;
            }

            return totalError;
        }

        /* ------------------------------------------------------------- */

        public static double[] GetSoftMax(this NeuralNetwork neuralNetwork)
        {
            // TODO
            return null;
        }

        public static int GetMaxIndex(this NeuralNetwork neuralNetwork)
        {
            double maxValue = double.MinValue;
            int maxIndex = 0;

            int count = neuralNetwork.outputLayer.neurons.Length;
            for (int i = 0; i < count; i++)
            {
                double output = neuralNetwork.GetOutput(i);
                if (output > maxValue)
                {
                    maxValue = output;
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        /* ------------------------------------------------------------- */

        public static void Train(this NeuralNetwork neuralNetwork, Data data, double learningRate)
        {
            double[] errors = null;
            for (int i = 0; i < data.trainInput.Count; i++)
            {
                neuralNetwork.SetInputs(data.trainInput[i]);
                neuralNetwork.FireNetwork();

                errors = neuralNetwork.GetErrors(data.trainOutput[i]);

                neuralNetwork.BackPropagate(errors, learningRate);
            }
        }

        public static void BackPropagate(this NeuralNetwork neuralNetwork, double[] errors, double learningRate)
        {
            for (int i = 0; i < errors.Length; i++)
                Correct(
                    neuralNetwork.outputLayer.neurons[i],
                    errors[i],
                    learningRate
                );
        }

        public static void Correct(this INeuron neuron, double error, double learningRate)
        {
            if (neuron.Synapses == null)
                return;

            double incoming = neuron.NeuronActivation.Derivative(neuron.Output) * error;
            foreach (ISynapse synapse in neuron.Synapses)
                Correct(synapse.From, incoming * synapse.Weight, learningRate);

            double delta = incoming * learningRate;
            foreach (ISynapse synapse in neuron.Synapses)
                synapse.Weight += delta * synapse.From.Output;

            neuron.Bias.Weight += delta;
        }
    }
}

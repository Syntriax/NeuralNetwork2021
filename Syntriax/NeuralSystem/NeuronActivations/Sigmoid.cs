using System;

namespace Syntriax.NeuralNetwork.NeuronActivations
{
    public class Sigmoid : INeuronActivation
    {
        public double Activation(double value) => 1.0 / (1.0 + Math.Exp(-value));

        public double Derivative(double value) => value * (1.0 - value);
    }
}

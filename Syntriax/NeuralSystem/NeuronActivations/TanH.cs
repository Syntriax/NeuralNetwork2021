using System;

namespace Syntriax.NeuralNetwork.NeuronActivations
{
    public class TanH : INeuronActivation
    {
        public double Activation(double value) => (Math.Exp(value) - Math.Exp(-value)) / (Math.Exp(value) + Math.Exp(-value));

        public double Derivative(double value) => 1.0 - value * value;
    }
}

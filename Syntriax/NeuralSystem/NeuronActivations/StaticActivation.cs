using System;

namespace Syntriax.NeuralNetwork.NeuronActivations
{
    public class StaticActivation<T> where T : INeuronActivation, new()
    {
        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

        public static T Instance => instance.Value;
    }
}

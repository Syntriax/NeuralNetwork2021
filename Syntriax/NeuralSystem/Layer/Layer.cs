using Syntriax.NeuralNetwork.NeuronActivations;

namespace Syntriax.NeuralNetwork
{
    public abstract class LayerBase
    {
        public INeuron[] neurons { get; protected set; } = null;

        public LayerBase(int neuronCount, LayerBase from = null) => SetLayer(neuronCount, from);

        protected abstract void SetLayer(int neuronCount, LayerBase from);

        public void FireLayer()
        {
            foreach (INeuron neuron in neurons)
                neuron.Calculate();
        }

        public void SetActivation(INeuronActivation neuronActivation)
        {
            foreach (INeuron neuron in neurons)
                neuron.NeuronActivation = neuronActivation;
        }
    }
}

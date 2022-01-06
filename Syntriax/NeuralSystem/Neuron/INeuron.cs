using Syntriax.NeuralNetwork.NeuronActivations;

namespace Syntriax.NeuralNetwork
{
    public interface INeuron
    {
        ISynapse[] Synapses { get; }
        ISynapse Bias { get; }
        INeuronActivation NeuronActivation { get; set; }
        double Output { get; }

        double Calculate();
    }
}

using Syntriax.NeuralNetwork.NeuronActivations;

namespace Syntriax.NeuralNetwork
{
    public class Neuron : INeuron
    {
        public ISynapse[] Synapses { get; private set; } = null;
        public ISynapse Bias { get; private set; } = null;

        public INeuronActivation NeuronActivation { get; set; } = new Default();

        public virtual double Output { get; private set; } = 0.0;

        public Neuron(INeuron[] neurons = null)
        {
            if (neurons == null)
            {
                Synapses = new Synapse[0];
                Bias = new Synapse();
                return;
            }

            Synapses = new ISynapse[neurons.Length];
            Bias = new Synapse();

            int length = neurons.Length;
            for (int i = 0; i < length; i++)
            {
                Synapses[i] = new Synapse();
                Synapses[i].From = neurons[i];
                // Synapses[i] = new MomentumSynapseDecorator(Synapses[i]); // TODO
            }
        }

        public double Calculate()
        {
            Output = 0.0;

            foreach (ISynapse synapse in Synapses)
                Output += synapse.Output;

            Output += Bias.Output;

            Output = NeuronActivation.Activation(Output);

            return Output;
        }
    }
}

using Syntriax.NeuralNetwork.NeuronActivations;

namespace Syntriax.NeuralNetwork
{
    public abstract class NeuronDecorator : INeuron
    {
        protected INeuron _neuron = null;

        public ISynapse[] Synapses => _neuron.Synapses;
        public ISynapse Bias => _neuron.Bias;

        public INeuronActivation NeuronActivation
        {
            get => _neuron.NeuronActivation;
            set => _neuron.NeuronActivation = value;
        }

        public virtual double Output { get; protected set; } = 0.0;

        protected NeuronDecorator(INeuron neuron) => _neuron = neuron;

        public virtual double Calculate()
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

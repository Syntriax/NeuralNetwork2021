namespace Syntriax.NeuralNetwork
{
    public class HiddenLayer : LayerBase
    {
        public HiddenLayer(int neuronCount, LayerBase from = null) : base(neuronCount, from) { }

        protected override void SetLayer(int neuronCount, LayerBase from)
        {
            neurons = new INeuron[neuronCount];

            for (int i = 0; i < neuronCount; i++)
            {
                neurons[i] = new Neuron(from == null ? null : from.neurons);
                // neurons[i] = new DropoutNeuronDecorator(neurons[i], 0.2); // TODO
            }
        }
    }
}

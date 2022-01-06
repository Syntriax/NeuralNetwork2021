namespace Syntriax.NeuralNetwork
{
    public class OutputLayer : HiddenLayer
    {
        public OutputLayer(int neuronCount, LayerBase from = null) : base(neuronCount, from) { }

        protected override void SetLayer(int neuronCount, LayerBase from)
        {
            neurons = new INeuron[neuronCount];

            for (int i = 0; i < neuronCount; i++)
                neurons[i] = new Neuron(from.neurons);
        }
    }
}

namespace Syntriax.NeuralNetwork
{
    public class InputLayer : LayerBase
    {
        public InputLayer(int neuronCount, LayerBase from = null) : base(neuronCount, from) { }

        protected override void SetLayer(int neuronCount, LayerBase from)
        {
            neurons = new Neuron[neuronCount];

            for (int i = 0; i < neuronCount; i++)
                neurons[i] = new InputNeuron();
        }
    }
}

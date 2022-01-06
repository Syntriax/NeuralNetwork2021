namespace Syntriax.NeuralNetwork
{
    public class InputNeuron : Neuron
    {
        public double Value = 0.0;

        public override double Output => Value;
    }
}

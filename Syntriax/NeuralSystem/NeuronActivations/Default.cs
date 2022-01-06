namespace Syntriax.NeuralNetwork.NeuronActivations
{
    public class Default : INeuronActivation
    {
        public double Activation(double value) => value;

        public double Derivative(double value) => value;
    }
}

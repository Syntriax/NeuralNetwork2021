namespace Syntriax.NeuralNetwork.NeuronActivations
{
    public interface INeuronActivation
    {
        double Activation(double value);
        double Derivative(double value);
    }
}

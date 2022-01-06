namespace Syntriax.NeuralNetwork.NeuronActivations
{
    public class Relu : INeuronActivation
    {
        public double Activation(double value)
        {
            if (value >= 0.0)
                return value;
            return 0.0;
        }

        public double Derivative(double value)
        {
            if (value >= 0.0)
                return 1.0;
            return 0.001;
        }
    }
}

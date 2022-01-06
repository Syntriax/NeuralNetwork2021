namespace Syntriax.NeuralNetwork
{
    public interface ISynapse
    {
        INeuron From { get; set; }
        double Output { get; }
        double Weight { get; set; }
    }
}

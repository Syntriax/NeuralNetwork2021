namespace Syntriax.NeuralNetwork
{
    public class NeuralNetwork
    {
        public LayerBase inputLayer { get; private set; } = null;
        public LayerBase[] hiddenLayers { get; private set; } = null;
        public LayerBase outputLayer { get; private set; } = null;

        public NeuralNetwork(int inputCount, int[] hiddenCounts = null, int outputCount = 1)
        {
            inputLayer = new InputLayer(inputCount);

            if (hiddenCounts != null && hiddenCounts.Length > 0)
            {
                int hiddenCount = hiddenCounts.Length;

                hiddenLayers = new HiddenLayer[hiddenCount];
                hiddenLayers[0] = new HiddenLayer(hiddenCounts[0], inputLayer);

                for (int i = 1; i < hiddenCount; i++)
                    hiddenLayers[i] = new HiddenLayer(hiddenCounts[i], hiddenLayers[i - 1]);

                outputLayer = new HiddenLayer(outputCount, hiddenLayers[hiddenLayers.Length - 1]);
                return;
            }

            outputLayer = new OutputLayer(outputCount, inputLayer);
        }

        public void FireNetwork()
        {
            if (hiddenLayers != null)
                foreach (LayerBase layer in hiddenLayers)
                    layer.FireLayer();

            outputLayer.FireLayer();
        }
    }
}

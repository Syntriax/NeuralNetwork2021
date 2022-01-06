namespace Syntriax.NeuralNetwork
{

    public class Synapse : ISynapse
    {
        private INeuron from = null;
        public INeuron From
        {
            get => from;
            set
            {
                if (from == null)
                    from = value;
            }
        }

        public double Output => Weight * (from == null ? 1.0 : from.Output);


        public double Weight { get; set; } = 0.0;

        public Synapse() { }
        public Synapse(INeuron from) => this.from = from;
    }
}

namespace Syntriax.NeuralNetwork
{
    public class MomentumSynapseDecorator : SynapseDecorator
    {
        private double _momentum = 0.0;
        private const double Beta = 0.9;

        public override double Weight
        {
            get => base.Weight;
            set
            {
                double difference = value - base.Weight;

                // TODO Might be an error here
                if (difference * _momentum >= 0.0 == _momentum >= 0.0)
                    base.Weight = value + _momentum * Beta;
                else
                    base.Weight = value;

                _momentum = difference;
            }
        }

        public MomentumSynapseDecorator(ISynapse synapse) : base(synapse) { }
    }
}

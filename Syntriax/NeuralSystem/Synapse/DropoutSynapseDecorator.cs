using System;

namespace Syntriax.NeuralNetwork
{
    public class DropoutSynapseDecorator : SynapseDecorator
    {
        public bool IsActive = false;
        public Random random = null;

        public override double Weight
        {
            get => base.Weight;
            set
            {
                if (random.Next() % 2 == 0)
                    base.Weight = 0;
                else
                    base.Weight = value;
            }
        }

        public DropoutSynapseDecorator(ISynapse synapse, Random random = null) : base(synapse)
            => SetRandom(random);

        public void SetRandom(Random random) => this.random = random;
    }
}

using System;

namespace Syntriax.NeuralNetwork
{
    public class DropoutNeuronDecorator : NeuronDecorator
    {
        private double dropoutRate = 0;
        public bool IsActive = false;
        public static Random Random = new Random(0);

        public DropoutNeuronDecorator(INeuron neuron, double dropoutRate) : base(neuron) => this.dropoutRate = dropoutRate;

        public override double Calculate()
        {
            base.Calculate();

            if (Random.NextDouble() < dropoutRate)
                Output = 0.0;

            return Output;
        }
    }
}

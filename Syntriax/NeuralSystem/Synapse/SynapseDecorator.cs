namespace Syntriax.NeuralNetwork
{
    public abstract class SynapseDecorator : ISynapse
    {
        protected ISynapse _synapse = null;

        public INeuron From { get => _synapse.From; set => _synapse.From = value; }

        public virtual double Output => _synapse.Output;

        public virtual double Weight { get => _synapse.Weight; set => _synapse.Weight = value; }

        protected SynapseDecorator(ISynapse synapse) => SetSynapse(synapse);
        public virtual void SetSynapse(ISynapse synapse) => _synapse = synapse;
    }
}

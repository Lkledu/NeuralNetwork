using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Neuron
{
    public float Gradient { get; set; }
    public float Value { get; set; }

    public float Bias { get; set; }
    public float BiasDelta { get; set/ }

    public List<Synapse> InputSynapses { get; set; }
    public List<Synapse> OutputSynapses { get; set; }

    public Neuron()
    {
        InputSynapses = new List<Synapse>();
        OutputSynapses = new List<Synapse>();
        Bias = Random.Range( -1.0f, 1.0f);
    }

    public Neuron(IEnumerable<Neuron> inputNeuronS) {
        foreach (var inputNeuron in inputNeuronS) {
            var synapse = new Synapse(inputNeuron, this);
            inputNeuron.OutputSynapses.Add(synapse);
            InputSynapses.Add(synapse);
        }
    }

    public float CalculateValue() {

        /*for (int i = 0; i < InputSynapses.Count; i++)
        {
            xSum += InputSynapses[i].Weight * InputSynapses[i].InputNeuron.Value;
        }
            ****** é o mesmo que fazer o Sum do LINQ
         */

        float xSum = InputSynapses.Sum(x => x.Weight * x.InputNeuron.Value);
        float u = xSum + Bias;
        Value = Sigmoid.Output(u);

        return Value;
    }

    public float CalculateError(float target) {
        return target - Value;
    }

    public float CalculateGradient(float ? target = null) {
        if (target == null) {
            return Gradient = OutputSynapses.Sum( x => x.OutputNeuton.Gradient * x.Weight) * Sigmoid.Derivative(Value);
        }

        return Gradient = CalculateError(target.Value) * Sigmoid.Derivative(Value);
    }

    public void UpdateWeights(float learnRate, float momentum) {
        float prevDelta = BiasDelta;
        BiasDelta = learnRate * Gradient;
        Bias += BiasDelta + momentum * prevDelta;

        foreach (var synapse in InputSynapses)
        {
            prevDelta = synapse.WeightDelta;
            synapse.WeightDelta = learnRate * Gradient * synapse.InputNeuron.Value;
            synapse.Weight += synapse.WeightDelta + momentum * prevDelta;
        }
    }

}
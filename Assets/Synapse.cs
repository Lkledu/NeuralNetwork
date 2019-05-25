using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synapse
{
    public Neuron InputNeuron { get; set; }
    public Neuron OutputNeuton { get; set; }
    public float Weight {get; set;}
    public float WeightDelta { get; set; }

    public Synapse(Neuron inNeuron, Neuron outNeuron) {
        InputNeuron = inNeuron;
        OutputNeuton = outNeuron;

        Weight = Random.Range(0.0f, 1.0f);
    }

}

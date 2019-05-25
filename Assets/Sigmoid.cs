using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Sigmoid
{
    public static float Output(float x) {


        return Mathf.Clamp01(1.0f / (1.0f + Mathf.Exp(- x)));
    }

    public static float Derivative(float x) {

        return x * (1 - x);
    }


}

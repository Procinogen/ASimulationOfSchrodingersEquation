using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProbFunc : MonoBehaviour
{
    private const float pi = 3.14159f;
    public int nx = 1;
    public int ny = 1;
    public static int L = 1;

    private double two = 2;
    public float waveFunctionProbability(float x, float y)
    {
        double N = 2 / L;
        float PsiX = Mathf.Sin((nx * pi * x) / L);
        float PsiY = Mathf.Sin((ny * pi * y) / L);
        double psi = N * PsiX * PsiY;
        float probability = (float)Math.Pow(Math.Abs(psi),(double)2);
        return probability;
    }

}

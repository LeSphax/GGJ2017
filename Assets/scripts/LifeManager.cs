using System;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static GameObject player;

    private static float life = 1.0f;
    WavesVisuals visuals;
    SinusMovement sinusMovement;

    public float lifeLossBaseRate = 1 / 3000f;

    private void Awake()
    {
        player = gameObject;
    }

    private void Start()
    {
        visuals = GetComponent<WavesVisuals>();
        sinusMovement = GetComponent<SinusMovement>();
    }

    void FixedUpdate()
    {
        float distanceFromBaseFrequency = sinusMovement.currentFrequency - sinusMovement.baseFrequency;
        float proportionalDistance;
        if (distanceFromBaseFrequency > 0)
            proportionalDistance = distanceFromBaseFrequency / (sinusMovement.frequencyMax - sinusMovement.baseFrequency);
        else
            proportionalDistance = distanceFromBaseFrequency / (sinusMovement.frequencyMin - sinusMovement.baseFrequency);

        Color color = new Color(1, 1 - proportionalDistance, 1 - proportionalDistance, life);

        visuals.SetColor(color);

        life -= lifeLossBaseRate + proportionalDistance * lifeLossBaseRate * 2;
        if (life <= 0)
        {
            //Insert loss logic here
            life = 0;
        }
    }

    //Negative numbers also work
    public static void IncreaseLife(float increaseAmount)
    {
        life += increaseAmount;
        if (life > 1)
            life = 1;
    }

}

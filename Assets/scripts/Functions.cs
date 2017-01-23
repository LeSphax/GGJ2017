using System;
using System.Collections.Generic;
using UnityEngine;

public static class Functions
{
    public static float GetHeight(float frequency, float x, float offset, float amplitude, float currentY)
    {
        return Mathf.Sin(frequency * (x + offset)) * amplitude + currentY;
    }

}

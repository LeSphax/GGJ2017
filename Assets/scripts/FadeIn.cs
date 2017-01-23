using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    private Color baseColor;

    private float animProgression = 0;

    public float duration;

    private bool fadeIn = false;
    private bool fadeOut = false;

    public void StartFadeIn()
    {
        fadeIn = true;
        StartAnim();
    }

    public void StartFadeOut()
    {
        fadeOut = true;
        StartAnim();
    }

    private void StartAnim()
    {
        gameObject.SetActive(true);
        baseColor = GetComponent<Image>().color;
        animProgression = 0;
        SetAlpha(animProgression);
    }

    private void SetAlpha(float alpha)
    {
        if (fadeIn)
            GetComponent<Image>().color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
        else if (fadeOut)
            GetComponent<Image>().color = new Color(baseColor.r, baseColor.g, baseColor.b, 1 - alpha);
    }

    private void Update()
    {
        animProgression += Time.deltaTime / duration;
        if (animProgression > 1)
        {
            if (fadeOut)
                gameObject.SetActive(false);
            Reset();
        }
        else
        {
            SetAlpha(animProgression);
        }
    }

    private void Reset()
    {
        fadeIn = false;
        fadeOut = false;
    }
}

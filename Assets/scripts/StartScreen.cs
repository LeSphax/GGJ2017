using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public MoveForward playerForward;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<FadeIn>().StartFadeOut();
            playerForward.enabled = true;
        }
    }
}

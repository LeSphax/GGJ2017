using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

    public SinusMovement sinusMovement;
    MoveForward self;
    public MoveForward player;

    // Use this for initialization
    void Start()
    {
        self= GetComponent<MoveForward>();
        RandomInvokeRandomChange();
    }

    private void RandomInvokeRandomChange()
    {
        Invoke("RandomChange", Random.Range(0.5f, 1f));
    }

    void RandomChange()
    {
        sinusMovement.SetFrequency(Random.Range(sinusMovement.frequencyMin, sinusMovement.frequencyMax));
        //sinusMovement.currentAmplitude = Random.Range(sinusMovement.amplitudeMin, sinusMovement.amplitudeMax);
        RandomInvokeRandomChange();
    }

    private void Update()
    {
        if (self.x > player.x + 20)
            self.x = player.x - 30;
    }
}

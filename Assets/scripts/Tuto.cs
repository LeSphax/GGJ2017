using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour {

	public GameObject frequency;
	public GameObject amplitude;
	public GameObject origin;

    private string state = "frequency";

	// Use this for initialization
	void Start () {
		frequency.SetActive(true);
		amplitude.SetActive(false);
		origin.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (state == "frequency") {
			if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D)) {
				frequency.SetActive(false);
                Invoke("Amplitude", 4);
                state = "";
            }
		}
		if (state == "amplitude") {
			if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.S)) {
				amplitude.SetActive(false);
                Invoke("Origin", 4);
                state = "";
            }
        }

        if (state == "origin")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                origin.SetActive(false);
            }
        }

    }

    void Amplitude()
    {
        state = "amplitude";
        amplitude.SetActive(true);
    }

    void Origin()
    {
        state = "origin";
        origin.SetActive(true);
    }
}

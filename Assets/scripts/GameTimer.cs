using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour {

    public static event EmptyEventHandler StartTransition;

    public float[] times;

    private float timer = 0;

    private int index;
	// Use this for initialization
	void Start () {
        timer = 0;
        index = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (index < times.Length && timer >= times[index])
        {
            index++;
            if (StartTransition != null)
                StartTransition.Invoke();
        }
	}
}

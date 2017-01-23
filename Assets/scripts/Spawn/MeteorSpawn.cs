using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour {

	[SerializeField] GameObject meteore;
	[SerializeField] GameObject[] spawn;
	[SerializeField] [Range(1,10)] float min;
	[SerializeField] [Range(1,10)] float max;

	// Use this for initialization
	void Start () {
		Invoke ("Spawn", Random.Range (min, max));
	}

	private void Spawn()
	{
		GameObject go = (GameObject)Instantiate (meteore);
		go.transform.position = spawn [Random.Range (0, spawn.Length)].transform.position;
		Invoke ("Spawn", Random.Range (min, max));
	}
}

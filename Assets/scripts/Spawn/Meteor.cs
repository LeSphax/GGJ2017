using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	[SerializeField] [Range (0,5)] int apparition;
	[SerializeField] [Range (0,1)] float scale;
	[SerializeField] AudioSource audioSource;

	private float actual;

	private bool stopAlpha;

	// Use this for initialization
	void Start () {
		actual = 0;
		stopAlpha = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (stopAlpha == false) {
			actual += Time.deltaTime;
			if (actual > apparition) {
				actual = apparition;
				stopAlpha = true;
				audioSource.Play ();
			}
			gameObject.transform.localScale = new Vector3 (scale * actual / apparition, scale * actual / apparition, scale * actual / apparition);
		}
	}
}

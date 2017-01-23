using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (BoxCollider2D))]
[RequireComponent(typeof (AudioSource))]

public class AmbianceSound : MonoBehaviour {


	[SerializeField] [Range(0,1)] float volume;
	[SerializeField] [Range(0,10)] float volumeTimeSwap;
	[SerializeField] AudioClip[] sound;

	private bool shutting;
	private bool starting;
	private bool colided;

	private AudioSource audioSource; 

	private float volumeTimer;

	public GameObject prevAmbianceSound;

	// Use this for initialization
	void Start () {
		shutting = false;
		starting = false;
		colided = false;
		audioSource = gameObject.GetComponent<AudioSource> ();
		//prevAmbianceSound = null;
		audioSource.clip = sound [0];
		volumeTimer = 0;
	}

	void Update() {
		if (shutting) {
			Shutting ();
		}
		else if (starting) {
			Starting ();
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && colided == false) {
			GameObject[] go = GameObject.FindGameObjectsWithTag ("AmbianceSound");
			/*for (int i = 0; i < go.Length; ++i)
				if (go [i] != gameObject) {
					prevAmbianceSound = go[i];
					break;
				}*/
			starting = true;
			colided = true;
			audioSource.volume = 0;
			audioSource.Play ();
			Invoke ("swapSound", sound [0].length);
			if (prevAmbianceSound != null)
				if (prevAmbianceSound.GetComponent<AmbianceSound> () != null)
					prevAmbianceSound.GetComponent<AmbianceSound> ().shutSound ();
			prevAmbianceSound = null;
		}
	}

	private void Shutting() {
		volumeTimer += Time.deltaTime;
		if (volumeTimer > volumeTimeSwap)
			volumeTimer = volumeTimeSwap;
		if (audioSource.volume != 0) {
			audioSource.volume = volume - (volume * volumeTimer) / volumeTimeSwap;
		} else {
			shutting = false;
			Destroy (this.gameObject);
		}
	}

	private void Starting() {
		volumeTimer += Time.deltaTime;
		if (volumeTimer > volumeTimeSwap)
			volumeTimer = volumeTimeSwap;
		if (audioSource.volume != volume) {
			audioSource.volume = (volume * volumeTimer) / volumeTimeSwap;
		} else {
			starting = false;
		}
	}

	private void swapSound() {
		audioSource.clip = sound [1];
		audioSource.loop = true;
		audioSource.Play ();
	}

	public void shutSound()
	{
		shutting = true;
		volumeTimer = 0;
	}
}

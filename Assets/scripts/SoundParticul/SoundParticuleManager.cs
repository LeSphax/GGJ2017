using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundParticuleManager : MonoBehaviour {

	[Range(0,1)] public float life;
	[SerializeField] GameObject _this;

	[SerializeField] private AudioClip[] sound;
	[SerializeField] private AudioSource audioSource;

	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private ParticleSystem particleAnimator;
	[SerializeField] private TrailRenderer trailRenderer;

	void Start () {
		audioSource.clip = sound [Random.Range (0, sound.Length)];
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy (_this, 1.0f);
			audioSource.Play();
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			spriteRenderer.enabled = false;
			particleAnimator.Stop ();
			trailRenderer.enabled = false;
			LifeManager.IncreaseLife (life);
		}
	}
}

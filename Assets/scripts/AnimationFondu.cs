using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFondu : MonoBehaviour
{

    public Sprite[] sprites;
	public bool loop;
    SpriteRenderer s_renderer;
    public SpriteRenderer nf_renderer;

    public float timestep = 0.5f;
    private float currentTime;

    private int nextFrame = 0;
	private bool stop;

    // Use this for initialization
    void Start()
    {
        s_renderer = GetComponent<SpriteRenderer>();
        //nf_renderer = GetComponentInChildren<SpriteRenderer>();
        ChangeFrame();
		stop = false;
    }

    // Update is called once per frame
    void ChangeFrame()
    {
        s_renderer.sprite = sprites[nextFrame];

        nextFrame++;
		if (!loop && nextFrame == sprites.Length) {
			stop = true;
			return;
		}
        nextFrame = nextFrame % sprites.Length;

        nf_renderer.sprite = sprites[nextFrame];

        s_renderer.color = new Color(s_renderer.color.r, s_renderer.color.g, s_renderer.color.b, 1);
        nf_renderer.color = new Color(nf_renderer.color.r, nf_renderer.color.g, nf_renderer.color.b, 0);

        currentTime = 0;
    }

    private void FixedUpdate()
    {
		if (stop == false) {
			currentTime += Time.fixedDeltaTime;
			float animationProportion = currentTime / timestep;
			s_renderer.color = new Color (s_renderer.color.r, s_renderer.color.g, s_renderer.color.b, 1 - animationProportion);
			nf_renderer.color = new Color (nf_renderer.color.r, nf_renderer.color.g, nf_renderer.color.b, animationProportion);

			if (animationProportion >= 1.0f) {
				ChangeFrame ();
			}
		}
    }
}

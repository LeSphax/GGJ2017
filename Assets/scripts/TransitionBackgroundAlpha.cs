using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBackgroundAlpha : MonoBehaviour
{

    private GameObject backgroundTwo;
    public float duration = 10.0f;

    private float startedSince = 0.0f;
    private bool started = false;

    private List<GameObject> statics;

    private float[] backgroundTwoStartAlphas;

    // Use this for initialization
    void Start()
    {
        statics = new List<GameObject>();
    }

    // Fuck it.
    void setAlpha(GameObject toChange, float alpha, bool useStartAlphas = false)
    {
        SpriteRenderer[] all = toChange.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < all.Length; i++)
        {
            float startAlpha = useStartAlphas ? backgroundTwoStartAlphas[i] : 1;
            all[i].color = new Color(all[i].color.r, all[i].color.g, all[i].color.b, startAlpha * alpha);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            foreach (GameObject backgroundOne in statics)
            {
                setAlpha(backgroundOne, 1 - startedSince / duration);
            }
            setAlpha(backgroundTwo, startedSince / duration, true);
            startedSince += Time.deltaTime;
            if (startedSince >= duration)
            {
                started = false;
                foreach (GameObject s in statics)
                {
                    Object.Destroy(s);
                }
                statics = new List<GameObject>();
            }
        }
    }

    public void startTransition(GameObject newBackground)
    {
        print("start");

        GameObject[] allObjs = Object.FindObjectsOfType<GameObject>();
        statics = new List<GameObject>();
        foreach (GameObject obj in allObjs)
            if (obj.GetComponent<SpriteRenderer>() && obj.GetComponent<SpriteRenderer>().sortingLayerName == "static")
                statics.Add(obj);

        print(statics.Count);
        if (statics.Count > 0)
            backgroundTwo = Object.Instantiate(newBackground, statics[0].transform.position, statics[0].transform.rotation);
        else
            backgroundTwo = Object.Instantiate(newBackground, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        GameObject.FindGameObjectWithTag("ParallaxManager").GetComponent<ParallaxHandler>().addObject(backgroundTwo);
        started = true;
        startedSince = 0.0f;

        SaveBackgroundTwoAlphas();
    }

    private void SaveBackgroundTwoAlphas()
    {
        SpriteRenderer[] renderers = backgroundTwo.GetComponentsInChildren<SpriteRenderer>();
        backgroundTwoStartAlphas = new float[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            backgroundTwoStartAlphas[i] = renderers[i].color.a;
        }
    }
}

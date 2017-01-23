using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    private bool hasBeenSeen = false;
    private bool isDestroying = false;
    private float destroyCD = 5.0f;

    List<Renderer> unseenRendereers;
    List<Renderer> seenRenderers;
    bool[] hasBeenSeens;

    // Use this for initialization
    void Start()
    {
        unseenRendereers = new List<Renderer>(GetComponentsInChildren<Renderer>());
        seenRenderers = new List<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Renderer r in new List<Renderer>(unseenRendereers))
        {
            if (r.isVisible)
            {
                unseenRendereers.Remove(r);
                seenRenderers.Add(r);
            }
        }


        if (AllBeenSeen() && !AnyVisible())
        {
            isDestroying = true;
        }
        else if (AnyVisible())
        {
            isDestroying = false;
            destroyCD = 5.0f;
        }
        if (isDestroying)
        {
            destroyCD -= Time.deltaTime;
            if (destroyCD <= 0.0f)
                GameObject.Destroy(gameObject);
        }
    }

    bool AllBeenSeen()
    {
        return unseenRendereers.Count == 0;
    }

    bool AnyVisible()
    {
        foreach (Renderer r in unseenRendereers)
        {
            if (r.isVisible)
                return true;
        }
        foreach (Renderer r in seenRenderers)
        {
            if (r.isVisible)
                return true;
        }
        return false;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class ParallaxHandler : MonoBehaviour
{

    public float backgroundSpeed = 0.1f;
    public float midgroundSpeed = 1.0f;
    public float foregroundSpeed = 5.0f;

    public GameObject[] defaultGameObjects;

    public GameObject forward;

    private float forwardSpeed = 0.0f;
    private HashSet<GameObject> bg = new HashSet<GameObject>();
    private HashSet<GameObject> mg = new HashSet<GameObject>();
    private HashSet<GameObject> fg = new HashSet<GameObject>();
    private HashSet<GameObject> statics = new HashSet<GameObject>();

    // Use this for initialization
    void Start()
    {
        foreach (GameObject item in defaultGameObjects)
        {
            addObject(item);
            item.transform.SetParent(MapTileSpawner.parent.transform);
        }
    }

    HashSet<GameObject> cleanHash(HashSet<GameObject> _set, List<GameObject> toRemove)
    {
        foreach (GameObject item in toRemove)
            _set.Remove(item);
        return _set;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (forward && forward.GetComponent<MoveForward>())
            forwardSpeed = forward.GetComponent<MoveForward>().speed;
        List<GameObject> toRemove = new List<GameObject>();
        foreach (GameObject item in bg)
        {
            if (item == null)
            {
                toRemove.Add(item);
                continue;
            }
            item.transform.Translate(new Vector3(-backgroundSpeed + forwardSpeed, 0, 0));
        }
        bg = cleanHash(bg, toRemove);
        toRemove = new List<GameObject>();
        foreach (GameObject item in mg)
        {
            if (item == null)
            {
                toRemove.Add(item);
                continue;
            }
            item.transform.Translate(new Vector3(-midgroundSpeed + forwardSpeed, 0, 0));
        }
        mg = cleanHash(mg, toRemove);
        toRemove = new List<GameObject>();
        foreach (GameObject item in fg)
        {
            if (item == null)
            {
                toRemove.Add(item);
                continue;
            }
            item.transform.Translate(new Vector3(-foregroundSpeed + forwardSpeed, 0, 0));
        }
        fg = cleanHash(fg, toRemove);
        toRemove = new List<GameObject>();
        foreach (GameObject item in statics)
        {
            if (item == null)
            {
                toRemove.Add(item);
                continue;
            }
            item.transform.Translate(new Vector3(forwardSpeed, 0, 0));
        }
        statics = cleanHash(statics, toRemove);
    }

    public void addObject(GameObject item)
    {
        if (item.GetComponentInChildren<Renderer>())
        {
            if (item.GetComponentInChildren<Renderer>().sortingLayerName == "background")
            {
                bg.Add(item);
            }
            else if (item.GetComponentInChildren<Renderer>().sortingLayerName == "midground")
            {
                mg.Add(item);
            }
            else if (item.GetComponentInChildren<Renderer>().sortingLayerName == "foreground")
            {
                fg.Add(item);
            }
            else if (item.GetComponentInChildren<Renderer>().sortingLayerName == "static")
            {
                statics.Add(item);
            }
        }
    }
}

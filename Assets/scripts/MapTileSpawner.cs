using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileSpawner : MonoBehaviour
{

    public static GameObject parent;

    private void Awake()
    {
        if (parent == null)
        {
            parent = new GameObject("Background");
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // get our sorting layer
        string layer = transform.parent.gameObject.GetComponentInChildren<Renderer>().sortingLayerName;
        Vector3 sizeX = GetComponentSize();
        //Debug.Log(transform.parent.name + "   " +  transform.parent.gameObject.GetComponent<Renderer>().bounds.size.x);
        // retrieve GameObjects to instantiates
        GameObject[] newLayer = GameObject.Find("TransitionManager").GetComponent<TransitionHandler>().getCurrentObjectsFromLayer(layer);
        foreach (GameObject go in newLayer)
        {
            // instantiate
            GameObject obj = Instantiate(go, transform.parent.transform.position + sizeX, new Quaternion(0, 0, 0, 0));
            foreach (Renderer r in obj.GetComponentsInChildren<Renderer>())
            {
                r.sortingLayerName = layer;
            }
            obj.AddComponent<SelfDestroy>();
            obj.transform.SetParent(parent.transform);
            GameObject.FindGameObjectWithTag("ParallaxManager").GetComponent<ParallaxHandler>().addObject(obj);
        }
        // Destroy ourself
        Destroy(gameObject);
    }

    private Vector3 GetComponentSize()
    {
        Vector3 sizeX;
        if (transform.parent.GetComponent<BoxCollider2D>() != null)
            sizeX = new Vector3(transform.parent.gameObject.GetComponent<BoxCollider2D>().bounds.size.x, 0, 0);
        else
            sizeX = new Vector3(transform.parent.gameObject.GetComponent<Renderer>().bounds.size.x, 0, 0);
        return sizeX;
    }
}

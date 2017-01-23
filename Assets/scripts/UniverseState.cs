using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseState : MonoBehaviour
{

    private static GameObject emptyLayerPrefab;
    private static GameObject EmptyLayerPrefab
    {
        get
        {
            if (emptyLayerPrefab == null)
            {
                emptyLayerPrefab = Resources.Load<GameObject>("EmptyLayer");
            }
            return emptyLayerPrefab;
        }
    }

    public string m_name;

    public bool isTransition;

    public GameObject statics;
    public GameObject[] background;
    public GameObject[] midground;
    public GameObject[] foreground;
    public GameObject[] game;

    private List<string> alreadyUsedLayers;

    private void Awake()
    {
        if (isTransition)
        {
            alreadyUsedLayers = new List<string>();
            Debug.LogWarning(alreadyUsedLayers.Count);
        }
    }

    public GameObject[] getFromLayer(string type)
    {
        //Debug.Log(this + "getFromLayer " + type + "  " + alreadyUsedLayers.Contains(type));
        if (isTransition && alreadyUsedLayers.Contains(type))
        {
            return new GameObject[1] { EmptyLayerPrefab };
        }
        else
        {
            GameObject[] result;
            if (isTransition)
            {
                alreadyUsedLayers.Add(type);
            }
            switch (type)
            {
                case "background":
                    result = background;
                    break;
                case "midground":
                    result = midground;
                    break;
                case "foreground":
                    result = foreground;
                    break;
                case "game":
                    result = game;
                    break;
                default:
                    result = new GameObject[0];
                    break;
            }
            if (result.Length == 0)
            {
                result = new GameObject[1] { EmptyLayerPrefab };
            }
            return result;
        }
    }

}

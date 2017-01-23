using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EmptyEventHandler();

public class TransitionHandler : MonoBehaviour
{

    public static event EmptyEventHandler transitionStarted;

    public GameObject[] statesPrefabs;
    private GameObject[] states;

    private int currentState;

    int findStateByName(string name)
    {
        for (int i = 0; i < states.Length; ++i)
        {
            GameObject state = states[i];
            if (state.GetComponent<UniverseState>().m_name == name)
            {
                return i;
            }
        }
        return 0;
    }

    public GameObject[] getCurrentObjectsFromLayer(string layer)
    {
        return getCurrentState().getFromLayer(layer);
    }

    public UniverseState getCurrentState()
    {
        return states[currentState].GetComponent<UniverseState>();
    }

    public void transition(string stateName)
    {
        currentState = findStateByName(stateName);
        if (!getCurrentState().isTransition)
            gameObject.GetComponent<TransitionBackgroundAlpha>().startTransition(getCurrentState().statics);

        if (transitionStarted != null)
            transitionStarted.Invoke();
    }

    public void transition()
    {
        if (currentState + 1 < states.Length)
            ++currentState;
        if (!getCurrentState().isTransition)
            gameObject.GetComponent<TransitionBackgroundAlpha>().startTransition(getCurrentState().statics);

        if (transitionStarted != null)
            transitionStarted.Invoke();
        Debug.Log(getCurrentState().name);
    }

    private void Awake()
    {
        states = new GameObject[statesPrefabs.Length];
        for (int i = 0; i < statesPrefabs.Length; i++)
        {
            states[i] = Instantiate(statesPrefabs[i]);
            states[i].transform.parent = transform;
        }
    }

    // Use this for initialization
    void Start()
    {
        currentState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transition();
        }
    }
}

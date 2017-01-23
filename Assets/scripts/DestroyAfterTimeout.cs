using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTimeout : MonoBehaviour {

	public void DestroyInXSeconds(float seconds)
    {
        Invoke("Destruction", seconds);
    }

    void Destruction()
    {
        Destroy(gameObject);
    }
}

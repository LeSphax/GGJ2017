using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float x = 0;
    public float speed = 1f;

    private void Start()
    {
        x = transform.localPosition.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		x += speed;
        transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
    }
}
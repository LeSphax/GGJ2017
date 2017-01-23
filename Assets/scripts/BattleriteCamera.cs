using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put on the camera
public class BattleriteCamera : MonoBehaviour
{

    public float maxXOffset;
    public float maxYOffset;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector2 clampedMousePosition = new Vector2(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width),
            Mathf.Clamp(Input.mousePosition.y, 0, Screen.height));

        float xDistanceToCenter = clampedMousePosition.x - Screen.width / 2.0f;
        float yDistanceToCenter = clampedMousePosition.y - Screen.height / 2.0f;

        float xProportion = xDistanceToCenter / (Screen.width / 2.0f);
        float yProportion = yDistanceToCenter / (Screen.height / 2.0f);
        Vector3 targetPosition = new Vector3(xProportion * maxXOffset, yProportion * maxYOffset, transform.localPosition.z);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, speed);

        //Debug.Log(xDistanceToCenter + "   " + yDistanceToCenter + "   " +)
    }
}

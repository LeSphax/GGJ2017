using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{

    private float timer;
    public float duration;

    public float yDelta;
    public AnimationCurve curve;

    private Vector3 startPosition;

    private bool initialised = false;

    public float speedInit;

    // Use this for initialization
    void Start()
    {
        timer = duration / 4;
        startPosition = new Vector3(Random.Range(-0.1f, -0.8f), 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!initialised)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPosition, speedInit);
            if (Vector3.Distance(transform.localPosition, startPosition) <= 0.1f)
                initialised = true;
        }
        else
        {
            timer += Time.fixedDeltaTime;
            float animationProportion = (timer % duration) * 2 / duration;
            if (animationProportion < 1)
            {
                animationProportion = curve.Evaluate(animationProportion);
                transform.localPosition = transform.localPosition + Vector3.up * (-transform.localPosition.y + (1 - animationProportion) * -yDelta + animationProportion * yDelta);
                transform.localPosition = transform.localPosition + Vector3.forward * (-transform.localPosition.z + Mathf.Sqrt(yDelta * yDelta - transform.localPosition.y * transform.localPosition.y));
            }
            else
            {
                animationProportion -= 1;
                animationProportion = curve.Evaluate(animationProportion);
                transform.localPosition = transform.localPosition + Vector3.down * (transform.localPosition.y + (1 - animationProportion) * -yDelta + animationProportion * yDelta);

                transform.localPosition = transform.localPosition + Vector3.back * (transform.localPosition.z + Mathf.Sqrt(yDelta * yDelta - transform.localPosition.y * transform.localPosition.y));
            }
        }
    }
}

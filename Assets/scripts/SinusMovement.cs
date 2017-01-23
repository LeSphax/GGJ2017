using UnityEngine;

public class SinusMovement : MonoBehaviour
{
    public MoveForward moveForward;

    public float baseFrequency = 3;
    public float baseAmplitude = 1;

    [HideInInspector]
    public float currentAmplitude;
    public float amplitudeChangeSpeed = 0.1f;
    public float amplitudeMax = 3f;
    public float amplitudeMin = 0.5f;

    float offset = 0;

    [HideInInspector]
    public float currentFrequency;
    public float freqencyChangeSpeed = 0.1f;
    public float frequencyMax = 3f;
    public float frequencyMin = 0.01f;

    public float offsetChangeSpeed = 0.2f;

    float currentY;

    private void Start()
    {
        currentY = transform.localPosition.y;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        BasicMovement();

        if (gameObject.tag == "Player")
        {
            ChangeAmplitude();

            //if (changeF)
            ChangeFrequency();

            //ChangeOffset();

            ChangeOrigin();
        }

    }

    private void BasicMovement()
    {
        float height = Functions.GetHeight(currentFrequency, moveForward.x, offset, currentAmplitude, currentY);
        transform.localPosition = transform.localPosition + Vector3.up * (height - transform.localPosition.y);
    }

    private void ChangeOrigin()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float oldOffset = offset;
            currentY = transform.localPosition.y;
            offset = -moveForward.x;
            float period = 2 * Mathf.PI / currentFrequency;
            float phase = (moveForward.x + oldOffset) % period;


            if (period / 4 < phase && phase < 3 * period / 4)
                offset += period / 2;
            //if (maxAmplitude)
            //{
            //    currentAmplitudeMax = amplitudeMax - Mathf.Abs(currentY);
            //    amplitude = Mathf.Min(amplitude, currentAmplitudeMax);
            //}
        }
    }

    private void ChangeOffset()
    {
        if (Input.GetKey(KeyCode.D))
        {
            offset += offsetChangeSpeed;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            offset -= offsetChangeSpeed;
        }
    }

    private void ChangeFrequency()
    {

        if (Input.GetKey(KeyCode.D) && currentFrequency < frequencyMax)
        {
            SetFrequency(currentFrequency * 1.01f);// freqencyChangeSpeed;
        }
        else if (Input.GetKey(KeyCode.Q) && currentFrequency > frequencyMin)
        {
            SetFrequency(currentFrequency / 1.01f);// freqencyChangeSpeed;
        }
    }

    public void SetFrequency(float newFrequency)
    {
        float oldFrequency = currentFrequency;

        currentFrequency = newFrequency;
        SmoothFrequencyChange(oldFrequency);
    }

    //Change the offset so the point will be at the same place on the curve with the new frequency
    private void SmoothFrequencyChange(float oldFrequency)
    {
        if (currentFrequency != oldFrequency)
        {
            offset = ((oldFrequency * (moveForward.x + offset)) / currentFrequency) - moveForward.x;

            //float oldPeriod = 2 * Mathf.PI / oldFrequency;
            //float newPeriod = 2 * Mathf.PI / frequency;
            //if (MoveForward.x % oldPeriod > oldPeriod / 2)
            //    offset += newPeriod / 2;
        }
    }

    private void ChangeAmplitude()
    {
        if (Input.GetKey(KeyCode.Z) && currentAmplitude < amplitudeMax)
        {
            currentAmplitude *= 1 + amplitudeChangeSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && currentAmplitude > amplitudeMin)
        {
            currentAmplitude /= 1 + amplitudeChangeSpeed;
        }
    }

    private void Reset()
    {
        currentFrequency = baseFrequency;
        currentAmplitude = baseAmplitude;
    }

    public float[][] GetPrevisualisationCoordinates(float xInterval, int maxNumberPoints)
    {
        float[][] result = new float[2][];
        result[0] = new float[maxNumberPoints];
        result[1] = new float[maxNumberPoints];

        for (int i = 0; i < maxNumberPoints; i++)
        {
            if (i == 0)
                result[0][i] = moveForward.x + xInterval;
            else
            {
                result[0][i] = result[0][i - 1] + xInterval;
                //Debug.Log(result[0][i - 1]);
            }
            result[1][i] = Functions.GetHeight(currentFrequency, result[0][i], offset, currentAmplitude, currentY);
        }
        return result;
    }
}

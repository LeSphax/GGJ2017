using UnityEngine;

public class AxisMovement : MonoBehaviour {

    public GameObject background;
    public GameObject m_camera;

    private float currentX;
    private float currentY;

    // Use this for initialization
    void Start () {

    }
    private void AxisControl()
    {
        if (Input.GetKey(KeyCode.S))
            currentY -= 0.1f;
        if (Input.GetKey(KeyCode.Z))
            currentY += 0.1f;
        if (Input.GetKey(KeyCode.Q))
            currentX -= 0.1f;
        if (Input.GetKey(KeyCode.D))
            currentX += 0.1f;
    }

    // Update is called once per frame
    void Update () {
        AxisControl();

        background.transform.localPosition = new Vector3(-currentX, -currentY, background.transform.localPosition.z);
        //m_camera.transform.localPosition = new Vector3(-currentX, m_camera.transform.localPosition.y, m_camera.transform.localPosition.z);

    }
}

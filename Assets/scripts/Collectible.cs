using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject particlePrefab;

    public Vector2[] positions;

    private void Awake()
    {
        int i = 0;
        foreach (Vector2 position in positions)
        {
            GameObject particle = Instantiate(particlePrefab);
            particle.transform.SetParent(transform);
            particle.transform.localPosition = new Vector3(position.x, position.y, 0);

            particle.GetComponentInChildren<SinusMovement>().moveForward = GetComponent<MoveForward>();
            particle.GetComponentInChildren<WavesVisuals>().SetColor(GameObject.FindGameObjectWithTag("WavesSpawner").GetComponent<WavesSpawner>().GetCurrentColor());

            i++;
        }
    }

    public void SetColor(Color color)
    {
        //foreach (WavesVisuals visual in visuals)
        //{
        //    visual.SetColor(color);
        //    visual.initialColor = color;
        //}
    }

}

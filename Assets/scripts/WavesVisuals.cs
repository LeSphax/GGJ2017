using UnityEngine;

public class WavesVisuals : MonoBehaviour
{

    public ParticleSystemRenderer m_particleSystem;
    TrailRenderer trailRenderer;
    SinusMovement sinusMovement;
    public SpriteRenderer head;

    public Color initialColor = Color.white;
    public GameObject previsualisationPointPrefab;

    public bool showPreview;
    public float xInterval;
    public int maxNumberPoints;

    private GameObject[] previsualisationPool;

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        sinusMovement = GetComponent<SinusMovement>();
    }

    private void Start()
    {
        if (showPreview)
        {
            GameObject previsualisationPoolParent = new GameObject("Previsualisation Pool");
            previsualisationPoolParent.transform.position = Vector3.zero;
            previsualisationPool = new GameObject[maxNumberPoints];
            for (int i = 0; i < maxNumberPoints; i++)
            {
                previsualisationPool[i] = Instantiate(previsualisationPointPrefab);
                previsualisationPool[i].transform.SetParent(previsualisationPoolParent.transform);
            }
        }
        SetColor(initialColor);
    }

    // Update is called once per frame
    void Update()
    {
        if (showPreview)
        {
            float[][] points = sinusMovement.GetPrevisualisationCoordinates(xInterval, maxNumberPoints);
            for (int i = 0; i < points[0].Length; i++)
            {
                previsualisationPool[i].transform.localPosition = new Vector3(points[0][i], points[1][i], previsualisationPool[0].transform.localPosition.z);

            }
        }
    }

    public void SetAlpha(float alpha)
    {
        trailRenderer.startColor = new Color(trailRenderer.startColor.r, trailRenderer.startColor.g, trailRenderer.startColor.b, alpha);
        trailRenderer.endColor = new Color(trailRenderer.endColor.r, trailRenderer.endColor.g, trailRenderer.endColor.b, alpha);
        //
        Color oldParticleColor = m_particleSystem.material.GetColor("_TintColor");
        m_particleSystem.material.SetColor("_TintColor", new Color(oldParticleColor.r, oldParticleColor.g, oldParticleColor.b, alpha));
        //
        head.color = new Color(head.color.r, head.color.g, head.color.b, alpha);
    }

    public void SetColor(Color color)
    {
        initialColor = color;
        trailRenderer.startColor = color;
        trailRenderer.endColor = color;
        //
        m_particleSystem.material.SetColor("_TintColor", color);
        //
        head.color = color;
    }
}

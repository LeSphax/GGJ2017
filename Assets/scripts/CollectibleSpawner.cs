using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{

    private LinkedList<GameObject> collectibles;

    public GameObject[] collectiblePrefabs;

    private MoveForward playerMoveForward;

    public float xDistanceMin;
    public float xDistanceMax;
    public float yMin;
    public float yMax;

    public bool spawning;

    private WavesSpawner wavesSpawner;

    void Start()
    {
        wavesSpawner = GameObject.FindGameObjectWithTag("WavesSpawner").GetComponent<WavesSpawner>();
        collectibles = new LinkedList<GameObject>();
        playerMoveForward = GameObject.FindGameObjectWithTag("MovingElements").GetComponent<MoveForward>();
        CurrentWorld.SetWorld(World.CLOUDS);
    }

    void Update()
    {
        if (spawning)
        {
            if (collectibles.Count > 0)
                if (playerMoveForward.x > collectibles.First.Value.transform.position.x + 2)
                {
                    RemoveLastCollectible();
                }
            while (collectibles.Count < 4)
            {
                SpawnNewCollectible();
            }
        }
    }

    private void RemoveLastCollectible()
    {
        GameObject collectibleToDestroy = collectibles.First.Value;
        collectibles.RemoveFirst();
        DestroyAfterTimeout dat = collectibleToDestroy.AddComponent<DestroyAfterTimeout>();
        dat.DestroyInXSeconds(60);
    }

    private void SpawnNewCollectible()
    {
        int i = Random.Range(0, collectiblePrefabs.Length);

        float lastCollectibleXPos;
        if (collectibles.Count == 0)
            lastCollectibleXPos = playerMoveForward.x;
        else
            lastCollectibleXPos = collectibles.Last.Value.transform.position.x;

        GameObject newCollectible = Instantiate(collectiblePrefabs[i]);
        collectibles.AddLast(newCollectible);
        newCollectible.transform.SetParent(transform);
        newCollectible.transform.position = new Vector3(lastCollectibleXPos + Random.Range(xDistanceMin, xDistanceMax), Random.Range(yMin, yMax), transform.position.z);

        newCollectible.GetComponent<Collectible>().SetColor(GetColor());
    }

    private Color GetColor()
    {
        return wavesSpawner.GetCurrentColor();
    }
}

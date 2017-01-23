using UnityEngine;
using UnityEngine.Audio;

public class WavesSpawner : MonoBehaviour
{

    public GameObject wavesPrefab;
    public GameObject endScreen;

    public AudioClip[] audios;
    public AudioMixerGroup[] mixerGroups;
    public Color[] colors;

    private MoveForward playerForward;

    private int current = 0;

    private void Start()
    {
        playerForward = GameObject.FindGameObjectWithTag("MovingElements").GetComponent<MoveForward>();
    }

    private void Update()
    {
        if (current == 0 && playerForward.x > 100)
            AddNextWave();
        if (current == 1 && playerForward.x > 300)
            AddNextWave();
        if (current == 2 && playerForward.x > 500)
            AddNextWave();
        if (current == 3 && playerForward.x > 700)
            AddNextWave();
        if (current > 0 && playerForward.x > 1100)
        {
            endScreen.GetComponent<FadeIn>().StartFadeIn();
            current = -1;
        }
    }

    void AddNextWave()
    {
        if (current < audios.Length)
        {
            AddWave(current);
            current++;
        }
    }

    public void AddWave(int waveNumber)
    {
        if (audios[waveNumber] != null)
        {
            GameObject friendlyWave = Instantiate(wavesPrefab);
            friendlyWave.GetComponentInChildren<FriendlyWave>().visuals.SetColor(colors[waveNumber]);
            friendlyWave.GetComponentInChildren<FriendlyWave>().audioSource.clip = audios[waveNumber];
            friendlyWave.GetComponentInChildren<FriendlyWave>().audioSource.outputAudioMixerGroup = mixerGroups[waveNumber];
            friendlyWave.GetComponentInChildren<FriendlyWave>().audioSource.Play();
            friendlyWave.transform.position = new Vector3(playerForward.x - 20, Random.Range(-9, 9), -2);
        }
    }

    public Color GetCurrentColor()
    {
        return colors[current];
    }
}

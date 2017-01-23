using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : MonoBehaviour
{
    public AudioSource audioSource;
	[SerializeField] GameObject myHead;
    private GameObject player;

    public float speed;

    // Use this for initialization
    void Awake()
    {
        GetComponent<UpAndDown>().enabled = false;
    }

    private void Start()
    {
        player = LifeManager.player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        if (Vector3.Distance(transform.position, player.transform.position) <= 0.1f)
        {
			myHead.tag = "Player";
            SoundModifier.audioSources.Add(audioSource);
            transform.SetParent(player.transform);
            GetComponent<UpAndDown>().enabled = true;
            this.enabled = false;
            LifeManager.IncreaseLife(1);

        }
    }
}

using UnityEngine;

public class trnastionPrefabSpawn : MonoBehaviour {

	public GameObject originTransition;

	public void instantiateTransition(GameObject transition)
	{
		GameObject go = (GameObject)Instantiate (transition);
		go.transform.position = originTransition.transform.position;
	}
}

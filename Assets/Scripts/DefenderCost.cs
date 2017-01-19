using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DefenderCost : MonoBehaviour {
	public GameObject[] prefabs;
	private Text[] texts;
	// Use this for initialization
	void Start () {
		texts = GetComponentsInChildren<Text> ();
		int i;
		for(i = 0; i < prefabs.Length; i++) {
			texts [i].text = prefabs[i].GetComponentInChildren<Defender> ().cost.ToString ();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public int GetCosts(int i){
		return prefabs [i].GetComponentInChildren<Defender> ().cost;
	}
}

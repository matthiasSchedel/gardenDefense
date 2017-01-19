using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
	public int starsPerCycle;
	private StareScore score;
	// Use this for initialization
	void Start () {
		score = FindObjectOfType<StareScore> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddStars() {
		score.AddStars(starsPerCycle);
	}

}
